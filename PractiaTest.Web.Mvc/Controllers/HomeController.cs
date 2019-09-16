using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiaTest.Models.Entities;
using PractiaTest.Web.Mvc.Services.Interfaces;

namespace PractiaTest.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiService">The api service injected</param>
        /// <param name="logger">The logger injected</param>
        /// <param name="configuration">The configuration injected</param>
        public HomeController(IApiService apiService, ILogger<HomeController> logger,
            IConfiguration configuration)
        {
            _apiService = apiService;
            _logger = logger;
            _configuration = configuration;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientsList()
        {
            return View(_apiService.GetClients());
        }

        public IActionResult ClientViewer(int id)
        {
            CompleteClient client = _apiService.GetCompleteClientById(id);

            if (client == null)
            {
                return BadRequest();
            }

            return View(client);
        }

        public IActionResult InvoiceViewer(int id)
        {
            CompleteInvoice invoice = _apiService.GetCompleteInvoiceById(id);

            if (invoice == null)
            {
                return BadRequest();
            }

            return View(invoice);
        }
    }
}