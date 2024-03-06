using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholeSaler.DTO;
using WholeSaler.Entity;
using WholeSaler.Facade;
using WholeSaler.IService;

namespace WholeSaler.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCrudService _orderCrudService;
        private readonly IOrderFacade _orderFacade;
        private readonly IMapper _mapper;

        public OrderController(IOrderCrudService orderCrudService, IOrderFacade orderFacade,IMapper mapper)
        {
            _orderCrudService = orderCrudService;
            _orderFacade = orderFacade;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGetDTO>> GetById([FromRoute] long id)
        {
            var order = await _orderCrudService.GetById(id);
            return Ok(_mapper.Map<OrderGetDTO>(order));
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            await _orderCrudService.Delete(id);
            return Ok();
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<OrderGetDTO>>> FindAll()
        {
            var orders=await _orderCrudService.FindAll();
            return Ok(_mapper.Map<IEnumerable<OrderGetDTO>>(orders));
        }
        [HttpPost("add_assortment")]
        public async Task<ActionResult> AddAssortmentToOrder([FromQuery] long assortmentId)
        {
            await _orderFacade.AddAssortmentToOrder(assortmentId);
            return Ok();
        }
 /*       [HttpPost("finalize")]
        public async Task<ActionResult> FinalizeOrder([FromRoute] long assortmentId)
        {
            await _orderFacade.AddAssortmentToOrder(assortmentId);
            return Ok();
        }*/
    }
}
