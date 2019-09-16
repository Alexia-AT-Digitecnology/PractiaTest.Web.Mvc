using System.Collections.Generic;
using PractiaTest.Models.Entities;

namespace PractiaTest.Web.Mvc.Services.Interfaces
{
    public interface IApiService
    {
        List<Client> GetClients();
        CompleteClient GetCompleteClientById(int clientId);
        CompleteInvoice GetCompleteInvoiceById(int invoiceId);
    }
}