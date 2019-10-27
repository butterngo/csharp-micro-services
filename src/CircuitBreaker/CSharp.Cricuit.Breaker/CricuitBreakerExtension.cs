namespace CSharp.Cricuit.Breaker.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;

    public static class CricuitBreakerExtension
    {
        public static IServiceCollection AdHttpClientCircuitBreaker<THttpClient>(this IServiceCollection services,
            string name, Action<HttpClient> configureClient)
            where THttpClient: StandardHttpClient
        {
            services.AddHttpClient<THttpClient>(name, configureClient);

            return services;
        }

        public static IServiceCollection AdHttpClientCircuitBreaker<THttpClient>(this IServiceCollection services,
            string name, Action<IServiceProvider, HttpClient> configureClient)
            where THttpClient : StandardHttpClient
        {
            services.AddHttpClient<THttpClient>(name, configureClient);

            return services;
        }
  
    }
}
