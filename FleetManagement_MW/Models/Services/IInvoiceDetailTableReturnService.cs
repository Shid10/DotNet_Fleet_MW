using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement_MW.Models.Services
{
    public interface IInvoiceDetailTableReturnService
    {
        Task<InvoiceDetailTableReturn> GetInvoiceDetail(long invoiceDetailId);
        Task<IEnumerable<InvoiceDetailTableReturn>> GetAllInvoiceDetails();
        Task<InvoiceDetailTableReturn> CreateInvoiceDetail(InvoiceDetailTableReturn invoiceDetail);
        Task<InvoiceDetailTableReturn> UpdateInvoiceDetail(long invoiceDetailId, InvoiceDetailTableReturn updatedInvoiceDetail);
        Task<bool> DeleteInvoiceDetail(long invoiceDetailId);
    }
}
