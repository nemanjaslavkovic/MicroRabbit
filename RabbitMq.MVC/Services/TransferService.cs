using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMq.MVC.Models.DTO;
using RabbitMq.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMq.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public IConfiguration _configuration { get; }
        private readonly string _bankingApiUrl;

        public TransferService(HttpClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
            _bankingApiUrl = _configuration["BankingApiURL"];
        }

        public async Task Transfer(TransferDto transferDto)
        {          
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), System.Text.Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(_bankingApiUrl, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
