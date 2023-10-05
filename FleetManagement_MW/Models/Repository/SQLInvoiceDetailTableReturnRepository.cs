using FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLInvoiceDetailTableReturnRepository : IInvoiceDetailTableReturnService

    {

        private readonly AppDbContext context;

        public SQLInvoiceDetailTableReturnRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<InvoiceDetailTableReturn> CreateInvoiceDetail(InvoiceDetailTableReturn invoiceDetail)
        {
            context.InvoiceDetailTableReturns.Add(invoiceDetail);
            await context.SaveChangesAsync();
            return invoiceDetail;
        }

        public async Task<bool> DeleteInvoiceDetail(long invoiceDetailId)
        {
            var existingInvoiceDetail = await context.InvoiceDetailTableReturns.FindAsync(invoiceDetailId);
            if (existingInvoiceDetail != null)
            {
                context.InvoiceDetailTableReturns.Remove(existingInvoiceDetail);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<InvoiceDetailTableReturn>> GetAllInvoiceDetails()
        {
            if (context.InvoiceDetailTableReturns == null)
            {
                return null;
            }
            return await context.InvoiceDetailTableReturns.ToListAsync();
        }

        public async Task<InvoiceDetailTableReturn> GetInvoiceDetail(long invoiceDetailId)
        {
            if (context.InvoiceDetailTableReturns == null)
            {
                return null;
            }
            var invoice = await context.InvoiceDetailTableReturns.FindAsync(invoiceDetailId);
            if (invoice == null)
            {
                return null;
            }
            return invoice;
        }

        public async Task<InvoiceDetailTableReturn> UpdateInvoiceDetail(long invoiceDetailId, InvoiceDetailTableReturn updatedInvoiceDetail)
        {
            var existingInvoiceDetail = await context.InvoiceDetailTableReturns.FindAsync(invoiceDetailId);
            if (existingInvoiceDetail != null)
            {
                // Update properties of existingInvoiceDetail with data from updatedInvoiceDetail
                await context.SaveChangesAsync();
            }
            return existingInvoiceDetail;
        }

    }
}
