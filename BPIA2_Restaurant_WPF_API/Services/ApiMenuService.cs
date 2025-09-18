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
    public class ApiMenuService
    {
        private readonly HttpClient _httpClient;

        public ApiMenuService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7181/api/")
            };
        }

        public async Task AddMenuAsync(Menu menu)
        {
            var response = await _httpClient.PostAsJsonAsync("Menu", menu);
            response.EnsureSuccessStatusCode();
        }
    }
}
