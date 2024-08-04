using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailDtoViewsController : ControllerBase
    {
        ICustomerDetailDtoService _customerDetailDtoService;

        public CustomerDetailDtoViewsController(ICustomerDetailDtoService customerDetailDtoService)
        {
            _customerDetailDtoService = customerDetailDtoService;
        }


        [HttpGet("getallcustomerdetail")]
        public IActionResult GetAllCustomerDetail()
        {
            var result = _customerDetailDtoService.GetAllCustomerDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
