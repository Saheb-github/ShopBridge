using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBride.BussinessEntities.Models;
using ShopBridge.BussinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.WEB.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ShopBridgeAdminController : ControllerBase
    {
        private readonly ISBProductManager _iSBProductManager;
        private readonly ILogger<ShopBridgeAdminController> _logger;
        public ShopBridgeAdminController(ISBProductManager isBProductManager, ILogger<ShopBridgeAdminController> logger)
        {
            _iSBProductManager = isBProductManager;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SBGetAllInventoryDetails()
        {
            try
            {
                var result = await _iSBProductManager.GetInventoryDetails();
                return (result != null) ? Ok(result) : Ok(null);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in SBGetAllInventoryDetails");
                throw ex;
            }
        }

        // PUT: api/Customer/5
        [HttpPut("Inventory")]
        public async Task<IActionResult> SBUpdateInventoryItem([FromBody] Inventory Item)
        {
            try
            {
                var result = await _iSBProductManager.IsInventoryItemUpdated(Item);
                return (result) ? Ok(result) : Ok(false);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in SBUpdateInventoryItem");
                throw ex;
            }
        }

        [HttpPost("Inventory")]
        public async Task<IActionResult> SBAddInventoryItem([FromBody] Inventory Item)
        {
            try
            {
                var result = await _iSBProductManager.AddInventory(Item);
                return (result) ? Ok(result) : Ok(false);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in SBAddInventoryItem");
                throw ex;
            }
        }

        [HttpDelete("Inventory/{id}")]
        public async Task<IActionResult> SBDeleteInventoryItem(int id)
        {
            try
            {
                var result = await _iSBProductManager.DeleteInventory(id);
                return (result) ? Ok(result) : Ok(false);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured in SBDeleteInventoryItem");
                throw ex;
            }
        }
    }
}
