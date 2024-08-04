using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalDetailDtoViewsController : ControllerBase
    {
        IRentalDetailDtoViewService _rentalDetailDtoViewService;

        public RentalDetailDtoViewsController(IRentalDetailDtoViewService rentalDetailDtoViewService)
        {
            _rentalDetailDtoViewService = rentalDetailDtoViewService;
        }

        [HttpGet("getallrentaldetails")]
        public IActionResult GetAll()
        {
            var result = _rentalDetailDtoViewService.GetAllRentalDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
