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
    public class StockItemController : ControllerBase
    {
        private readonly IStockItemApplication _stockItemApplication;
        public StockItemController(IStockItemApplication stockItemApplication)
        {
            _stockItemApplication = stockItemApplication;
        }

        [Produces("application/json")]
        [HttpPost("InsertStockItem")]
        public IActionResult InsertStockItem(StockItem stockItem)
        {
            try
            {
                var result = _stockItemApplication.InsertStockItem(stockItem);

                if (!result)
                {
                    return BadRequest("Não foi possivel inserir o estoque");
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPut("AddStockItem")]
        public IActionResult AddStockItem(StockItem stockItem)
        {
            try
            {
                var result = _stockItemApplication.AddStockItem(stockItem);

                if (!result)
                {
                    return BadRequest("Não foi possivel inserir o item ao estoque");
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpPut("RemoveStockItem")]
        public IActionResult RemoveStockItem(StockItem stockItem)
        {
            try
            {
                var result = _stockItemApplication.RemoveStockItem(stockItem);

                if (!result)
                {
                    return BadRequest("Não foi possivel inserir o item ao estoque");
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
