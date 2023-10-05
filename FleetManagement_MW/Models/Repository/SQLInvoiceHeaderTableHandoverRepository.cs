using FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLInvoiceHeaderTableHandoverRepository: IInvoiceHeaderTableHandoverService
    {
        private readonly AppDbContext context;

        public SQLInvoiceHeaderTableHandoverRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<InvoiceHeaderTableHandover>CreateInvoice(InvoiceHeaderTableHandover invoice)
        {
            context.InvoiceHeaderTableHandovers.Add(invoice);
            await context.SaveChangesAsync();
            return invoice;
            
        }

        public async Task<bool>DeleteInvoice(long invoiceId)
        {
            var existingInvoice = await context.InvoiceHeaderTableHandovers.FindAsync(invoiceId);
            if (existingInvoice != null)
            {
               context.InvoiceHeaderTableHandovers.Remove(existingInvoice);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
       
    }

        public async Task<IEnumerable<InvoiceHeaderTableHandover>?>GetAllInvoices()
        {
            if(context.InvoiceHeaderTableHandovers == null)
            {
                return null;
            }
            return await context.InvoiceHeaderTableHandovers.ToListAsync();
        }

        public async Task<InvoiceHeaderTableHandover>GetInvoice(long invoiceId)
        {
            if(context.InvoiceHeaderTableHandovers == null)
            {
                return null;
            }
            var invoice = await context.InvoiceHeaderTableHandovers.FindAsync(invoiceId);
            if(invoice == null)
            {
                return null;
            }
            return invoice;
        }

        public async Task<InvoiceHeaderTableHandover>UpdateInvoice(long id, InvoiceHeaderTableHandover invoice)
        {
           if(id!= invoice.invoiceId)
            {
                return null;
            }
           context.Entry(invoice).State = EntityState.Modified;

            try
            {
                context.Update(invoice);
                await context.SaveChangesAsync();

            }
            catch(DbUpdateConcurrencyException)
            {
                if(!InvoiceExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }

        

        private bool InvoiceExists( long id ) {
            return (context.InvoiceHeaderTableHandovers?.Any(i => i.invoiceId == id)).GetValueOrDefault();

        }
    }
}
