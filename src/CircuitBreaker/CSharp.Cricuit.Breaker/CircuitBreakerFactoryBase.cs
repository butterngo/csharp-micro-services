namespace CSharp.Cricuit.Breaker
{
    using Polly;
    using Polly.CircuitBreaker;
    using Polly.Retry;
    using System;
    using System.Threading.Tasks;

    public abstract class CircuitBreakerFactoryBase<TException, TResult>
        where TException: Exception
        where TResult: class
    {
        protected readonly AsyncCircuitBreakerPolicy<TResult> _breaker;

        protected abstract TimeSpan PauseBetweenFailures { get; }

        protected abstract TimeSpan DurationOfBreak { get; }

        protected virtual int HandledEventsAllowedBeforeBreaking => 2;

        protected readonly AsyncRetryPolicy<TResult> _retryPolicy;

        protected abstract int RetryTime { get; }

        public CircuitBreakerFactoryBase()
        {
            _breaker = InitializeCircuitBreakerPolicy();

            _retryPolicy = InitializeRetryPolicy();
        }

        public virtual async Task<TResult> ExecuteAsync(Func<Task<TResult>> action)
        {
            return await _retryPolicy.ExecuteAsync(async () =>
                   await _breaker.ExecuteAsync(async () => await action.Invoke()));
        }

        protected abstract bool OnHandleResult(TResult result);

        private AsyncCircuitBreakerPolicy<TResult> InitializeCircuitBreakerPolicy()
        => Policy.HandleResult<TResult>(r => OnHandleResult(r))
                           .CircuitBreakerAsync(HandledEventsAllowedBeforeBreaking,
                          DurationOfBreak,
                          OnBreak,
                          OnReset,
                          OnHalfOpen);

        private AsyncRetryPolicy<TResult> InitializeRetryPolicy()
        {
            int count = 1;

            var retryPolicy = Policy.Handle<TException>(exception => OnHandleException(exception))
                .OrResult<TResult>(result => OnHandleResult(result))
                .WaitAndRetryAsync(RetryTime, retryAttempt => PauseBetweenFailures,
                (exception, timeSpan, context) =>
                {
                    OnRetry(exception, timeSpan, context, count);

                    count++;
                });

            return retryPolicy;
        }

        protected abstract void OnRetry(DelegateResult<TResult> result,
            TimeSpan timeSpan,
            Context context,
            int retryCount);

        protected virtual bool OnHandleException(TException exception)
        {
            return exception.GetType() == typeof(TException);
        }

        protected virtual void OnHalfOpen()
        {
            //TODO Some logic
        }

        protected virtual void OnReset(Context context)
        {
            //TODO Some logic
        }

        protected virtual void OnBreak(DelegateResult<TResult> result, TimeSpan timeSpan, Context context)
        {
            //TODO Some logic
        }
    }
}
