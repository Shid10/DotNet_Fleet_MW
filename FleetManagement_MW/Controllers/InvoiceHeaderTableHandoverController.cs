using FleetManagement_MW.Models.Services;
using FleetManagement_MW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace FleetManagement_MW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class InvoiceHeaderTableHandoverController : ControllerBase
    {
        private readonly IInvoiceHeaderTableHandoverService _repository;
        public InvoiceHeaderTableHandoverController(IInvoiceHeaderTableHandoverService repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<InvoiceHeaderTableHandover>>> GetAllInvoices()
        {
            var invoices = await _repository.GetAllInvoices();
            return Ok(invoices);
        }
        [HttpGet("{id:long}")]

        public async Task<ActionResult<InvoiceHeaderTableHandover>> GetById(long id)
        {
            var invoice = await _repository.GetInvoice(id);
            return invoice == null ? NotFound() : invoice;

        }

        /*[HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetInvoicesByName(string invoiceName)
        {
            var invoices = await _repository.GetInvoicesByName(invoiceName);

            if (invoices == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(invoices);
            }
        }*/

        [HttpPut("{invoiceId}")]
        public async Task<ActionResult<InvoiceHeaderTableHandover>> UpdateInvoice(long invoiceId, InvoiceHeaderTableHandover updatedInvoice)
        {
            var invoice = await _repository.UpdateInvoice(invoiceId, updatedInvoice);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }
        [HttpDelete("{invoiceId}")]
        public async Task<ActionResult> DeleteInvoice(long invoiceId)
        {
            var result = await _repository.DeleteInvoice(invoiceId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
