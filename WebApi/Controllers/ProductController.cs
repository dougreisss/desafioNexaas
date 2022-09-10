using Application.Interface;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [Produces("application/json")]
        [HttpGet("ProductById")]
        public IActionResult ProductById(int productId)
        {
            try
            {
                var result = _productApplication.ProductById(productId);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPost("InsertProduct")]

        public IActionResult InsertProduct(Product product)
        {
            try
            {
                var result = _productApplication.InsertProduct(product);

                if (!result)
                {
                    return BadRequest("Não foi possivel inserir novo produto");
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                var result = _productApplication.UpdateProduct(product);

                if (!result)
                {
                    return BadRequest("Não foi possivel realizar update no produto");
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var result = _productApplication.DeleteProduct(productId);

                if (!result)
                {
                    return BadRequest("Não foi possivel realizar delete no produto");
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
