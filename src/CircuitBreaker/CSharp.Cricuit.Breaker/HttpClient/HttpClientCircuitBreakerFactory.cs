namespace CSharp.Cricuit.Breaker
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Polly;

    public class HttpClientCircuitBreakerFactory :
        CircuitBreakerFactoryBase<HttpRequestException, HttpResponseMessage>
    {
        protected override TimeSpan PauseBetweenFailures => TimeSpan.FromMilliseconds(1000);

        protected override TimeSpan DurationOfBreak => TimeSpan.FromMilliseconds(1000);

        protected override int RetryTime => 3;

        protected readonly HttpStatusCode[] _httpStatusCodes;

        public HttpClientCircuitBreakerFactory() 
        {
            _httpStatusCodes = new HttpStatusCode[] {
                HttpStatusCode.RequestTimeout, //408
                HttpStatusCode.InternalServerError, //500
                HttpStatusCode.BadGateway, //502
                HttpStatusCode.ServiceUnavailable, //503
                HttpStatusCode.GatewayTimeout //504
            };
        }

        protected override bool OnHandleResult(HttpResponseMessage result)
        => _httpStatusCodes.Contains(result.StatusCode);

        protected override void OnRetry(DelegateResult<HttpResponseMessage> result,
            TimeSpan timeSpan,
            Context context,
            int retryCount)
        {
            //TODO: Logic
        }
    }
}
