using Microsoft.AspNetCore.Mvc;
using WholeSaler.Entity;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderCrudService _orderCrudService;

        public InvoiceController(IInvoiceService inoviceService, IOrderCrudService orderCrudService)
        {
            _invoiceService = inoviceService;
            _orderCrudService = orderCrudService;
        }
        [HttpGet("get_invoice")]
        public async Task<ActionResult> GenerateInvoice([FromQuery] long orderId) {
            Order order = await _orderCrudService.GetOrderWithAssortment(orderId);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.Headers.Add("content-disposition", "attachment;filename=Invoice.pdf");
            try
            {
                var document = await _invoiceService.GenerateInvoice(order);
                await Response.Body.WriteAsync(document, 0, document.Length);
                Response.Body.Flush();
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return BadRequest("Wystąpił błąd: " + ex.Message);
            }
        }
    }
}
