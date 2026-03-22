using FinanceApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _service;

        public SuppliersController(SupplierService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            _service.Create(name);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("with-balance")]
        public IActionResult GetWithBalance()
        {
            return Ok(_service.GetWithBalance());
        }
    }
}