using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Validators;
using WebAPI.Filter;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;

        public ProductController(ProductService baseProductService)
        {
            _productService = baseProductService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber);
            
            IEnumerable<Product> data = _productService.GetAll();
            
            var pagedData = data
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return Ok(new PagedResponse<List<Product>>(pagedData, validFilter.PageNumber, validFilter.PageSize, data.Count()));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _productService.GetById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            return Execute(() => _productService.Add<ProductValidator>(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            return Execute(() => _productService.Update<ProductValidator>(product));
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Execute(() =>
            {
                _productService.DeleteLogic(id);
                return true;
            });
            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(new Response<object>(result));
            }
            catch (Exception ex)
            {
                var response = new Response<object>
                {
                    Message = ex.Message,
                    Succeeded = false
                };
                return BadRequest(response);
            }
        }
    }
}
