using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PractiaTest.Models.Entities;
using PractiaTest.Models.Responses;
using PractiaTest.Web.Mvc.Helpers;
using PractiaTest.Web.Mvc.Services.Interfaces;
using RestSharp;

namespace PractiaTest.Web.Mvc.Services.Implementations
{
    public class ApiService : IApiService
    {
        private readonly IConfiguration _configuration;
        
        public ApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<Client> GetClients()
        {
            var client = new RestClient("http://" + _configuration[PreferencesManagerOptionsHelper.ServiceApiHost] + ":" + _configuration[PreferencesManagerOptionsHelper.ServiceApiPort]);
            
            var request = new RestRequest("/api/Clients/GetAll", Method.GET);

            IRestResponse<Result<List<Client>>> response = client.Execute<Result<List<Client>>>(request);

            return response.Data.Data;
        }

        public CompleteClient GetCompleteClientById(int clientId)
        {
            var client = new RestClient("http://" + _configuration[PreferencesManagerOptionsHelper.ServiceApiHost] + ":" + _configuration[PreferencesManagerOptionsHelper.ServiceApiPort]);
            
            var request = new RestRequest("/api/Clients/GetCompleteById", Method.GET);
            request.AddParameter("clientId", clientId);

            IRestResponse<Result<CompleteClient>> response = client.Execute<Result<CompleteClient>>(request);

            return response.Data.Data;
        }

        public CompleteInvoice GetCompleteInvoiceById(int invoiceId)
        {
            var client = new RestClient("http://" + _configuration[PreferencesManagerOptionsHelper.ServiceApiHost] + ":" + _configuration[PreferencesManagerOptionsHelper.ServiceApiPort]);
            
            var request = new RestRequest("/api/Invoices/GetCompleteById", Method.GET);
            request.AddParameter("invoiceId", invoiceId.ToString());

            IRestResponse<Result<CompleteInvoice>> response = client.Execute<Result<CompleteInvoice>>(request);

            return response.Data.Data;
        }
    }
}