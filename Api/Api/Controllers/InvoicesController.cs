using Microsoft.AspNetCore.Mvc;

using Models;
using Services;

namespace Controllers {
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController(IInvoiceService invoiceService) : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetAllInvoices(){
            return Ok(await invoiceService.GetInvoices());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice([FromRoute] int id){
            return Ok(await invoiceService.GetInvoice(id));
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> AddUser([FromBody] Invoice invoice){
            return Ok(await invoiceService.AddInvoice(invoice));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] Invoice invoice){
            await invoiceService.UpdateInvoice(invoice);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id){
            await invoiceService.DeleteInvoice(id);

            return Ok();
        }
    }   
}