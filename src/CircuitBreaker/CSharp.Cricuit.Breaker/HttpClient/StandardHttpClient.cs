namespace CSharp.Cricuit.Breaker
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class StandardHttpClient : HttpClient
    {
        protected readonly HttpClientCircuitBreakerFactory _breaker;

        public StandardHttpClient(HttpClientCircuitBreakerFactory breaker) 
        {
            _breaker = breaker;
        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return await _breaker.ExecuteAsync(()=> base.SendAsync(request, cancellationToken));
        }
    }
}
