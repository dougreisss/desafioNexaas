using Application.Interface;
using Entity.Model;
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
    public class StoreController : ControllerBase
    {
        private IStoreApplication _storeApplication;

        public StoreController(IStoreApplication storeApplication)
        {
            _storeApplication = storeApplication;
        }

        [Produces("application/json")]
        [HttpGet("StoreById")]
        public IActionResult StoreById(int storeId)
        {
            try
            {
                var result = _storeApplication.StoreById(storeId);

                if (result == null)
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
        [HttpPost("InsertStore")]
        public IActionResult InsertStore(Store store)
        {
            try
            {
                var result = _storeApplication.InsertStore(store);

                if (!result)
                {
                    return BadRequest("Não foi possivel inserir uma nova loja");
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore(Store store)
        {
            try
            {
                var result = _storeApplication.UpdateStore(store);

                if (!result)
                {
                    return BadRequest("Não foi possivel realizar o update da loja");
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpDelete("DeleteStore")]

        public IActionResult DeleteStore(int storeId)
        {
            try
            {
                var result = _storeApplication.DeleteStore(storeId);

                if (!result)
                {
                    return BadRequest("Não foi possivel deletar loja");
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
