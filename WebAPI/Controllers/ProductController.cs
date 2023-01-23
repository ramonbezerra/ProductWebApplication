using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBaseService<Product> _baseProductService;

        public ProductController(IBaseService<Product> baseProductService)
        {
            _baseProductService = baseProductService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProductService.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _baseProductService.GetById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return Execute(() => _baseProductService.Add<ProductValidator>(product).Id);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            return Execute(() => _baseProductService.Update<ProductValidator>(product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Execute(() =>
            {
                _baseProductService.Delete(id);
                return true;
            });
            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
