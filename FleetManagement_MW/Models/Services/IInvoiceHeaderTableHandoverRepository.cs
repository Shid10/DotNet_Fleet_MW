using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement_MW.Models.Services
{
    public interface IInvoiceHeaderTableHandoverService
    {
        Task<InvoiceHeaderTableHandover> GetInvoice(long invoiceId);
        Task<IEnumerable<InvoiceHeaderTableHandover>> GetAllInvoices();
        Task<InvoiceHeaderTableHandover> CreateInvoice(InvoiceHeaderTableHandover invoice);
        Task<InvoiceHeaderTableHandover> UpdateInvoice(long invoiceId, InvoiceHeaderTableHandover updatedInvoice);
        Task<bool> DeleteInvoice(long invoiceId);
 
    }
}