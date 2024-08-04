using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailDtosController : ControllerBase
    {
        ICarDetailDtoService _carDetailDtoService;

        public CarDetailDtosController(ICarDetailDtoService carDetailDtoService)
        {
            _carDetailDtoService = carDetailDtoService;
        }
        [HttpGet("getallcardetails")]
        public IActionResult GetAll()
        {
            var result = _carDetailDtoService.GetAllCarDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
