using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BPIA2_Restaurant_WPF_API.Models;

namespace BPIA2_Restaurant_WPF_API.Services
{
    public class ApiArticleService
    {
        private readonly HttpClient _httpClient;

        public ApiArticleService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7181/api/") 
            };
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Article>>("Article");
        }
    }
}
