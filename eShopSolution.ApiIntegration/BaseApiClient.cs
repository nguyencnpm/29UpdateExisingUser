using eShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected BaseApiClient(IHttpClientFactory httpClientFactory
            , IHttpContextAccessor httpContextAccessor
            , IConfiguration configuration
            )
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // List<LanguageVm> myDeserializeObject = (List<LanguageVm>)JsonConvert.DeserializeObject(body, typeof(List<LanguageVm>));
                // return new ApiSuccessResult<List<LanguageVm>>(myDeserializeObject);
                TResponse myDeserializeObject = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializeObject;
            }
            // return JsonConvert.DeserializeObject<ApiErrorResult<List<LanguageVm>>>(body);
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        protected async Task<List<T>> GetListAsync<T>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var bearerToken = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // List<LanguageVm> myDeserializeObject = (List<LanguageVm>)JsonConvert.DeserializeObject(body, typeof(List<LanguageVm>));
                // return new ApiSuccessResult<List<LanguageVm>>(myDeserializeObject);
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            // return JsonConvert.DeserializeObject<ApiErrorResult<List<LanguageVm>>>(body);
            throw new Exception(body);
        }
    }
}
