using Application.Desafio.Easynvest.Services.FixedIncome;
using Application.Desafio.Easynvest.Services.Funds;
using Desafio.Easynvest.WebApi.Options;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Refit;
using System;
using Polly.Retry;
using System.Net.Http;
using Polly.Timeout;
using Application.Desafio.Easynvest.Services.DirectTreasure;

namespace Desafio.Easynvest.WebApi.Extensions
{
    public static class RefitExtensions
    {
        public static IServiceCollection ConfigurarRefit(this IServiceCollection services, PoliciesOptions policies, string urlBase)
        {
            //Definindo policies de Retry e timeout
            AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(policies.WaitAndRetryConfig.Retry, _ => TimeSpan.FromMilliseconds(policies.WaitAndRetryConfig.Wait));

            AsyncTimeoutPolicy<HttpResponseMessage> timeoutPolicy = Policy
              .TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMilliseconds(policies.WaitAndRetryConfig.Timeout));

            //Adicionar o client do Refit nas interfaces de serviços 
            services.AddRefitClient<IFixedIncomeServices>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(urlBase))
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);
            services.Decorate<IFixedIncomeServices, FixedIncomeServices>();

            services.AddRefitClient<IFundsServices>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(urlBase))
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);
            services.Decorate<IFundsServices, FundsServices>();

            services.AddRefitClient<IDirectTreasureServices>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(urlBase))
                .AddPolicyHandler(retryPolicy)
                .AddPolicyHandler(timeoutPolicy);
            services.Decorate<IDirectTreasureServices, DirectTreasureServices>();

            return services;
        }
    }
}
