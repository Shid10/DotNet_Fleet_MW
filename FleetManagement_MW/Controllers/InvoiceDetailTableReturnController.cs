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
    public class InvoiceDetailTableReturnController : ControllerBase
    {



        private readonly IInvoiceDetailTableReturnService _invoiceDetailTableReturnService;
        public InvoiceDetailTableReturnController(IInvoiceDetailTableReturnService returnService)
        {
            _invoiceDetailTableReturnService = returnService;
        }
        /* // GET: api/<ReturnHandoverinvoce>
         [HttpGet]
         public async Task<ActionResult< IEnumerable<InvoiceDetailTableReturn>>> GetInvoiceDetail()
         {
             if (await _invoiceDetailTableReturnService.GetAllInvoiceDetails() == null)
             {
                 return NotFound();
             }

             return await _invoiceDetailTableReturnService.GetAllInvoiceDetails();

         }*/


        // GET api/<ReturnHandoverinvoce>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailTableReturn>> GetById(long id)
        {
            var iinvoice = await _invoiceDetailTableReturnService.GetInvoiceDetail(id);
            return iinvoice == null ? NotFound() : iinvoice;
        }





    }
}