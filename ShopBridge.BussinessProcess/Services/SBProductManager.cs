using ShopBride.BussinessEntities.Models;
using ShopBridge.BussinessProcess.Interfaces;
using ShopBridge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.BussinessProcess.Services
{
    public class SBProductManager : ISBProductManager
    {
        readonly IInventoryRepository _inventoryRepository = null;

        public SBProductManager(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public Task<List<Inventory>> GetInventoryDetails()
        {
            var prodDetails = _inventoryRepository.GetAll();
            if (prodDetails != null)
            {
                return Task.FromResult(prodDetails);
            }
            return Task.FromResult<List<Inventory>>(null);
        }

        public Task<bool> IsInventoryItemUpdated(Inventory inventory)
        {
            bool isprodUpdated = _inventoryRepository.UpdateInventoryItem(inventory);
            if (isprodUpdated)
            {
                return Task.FromResult(isprodUpdated);
            }
            return Task.FromResult<bool>(false);
        }

        public Task<bool> AddInventory(Inventory inventory)
        {
            bool isprodAdded = _inventoryRepository.AddInventoryItem(inventory);
            if (isprodAdded)
            {
                return Task.FromResult(isprodAdded);
            }
            return Task.FromResult<bool>(false);
        }

        public Task<bool> DeleteInventory(int id)
        {
            bool isprodDeleted = _inventoryRepository.DeleteteInventoryItem(id);
            if (isprodDeleted)
            {
                return Task.FromResult(isprodDeleted);
            }
            return Task.FromResult<bool>(false);
        }
    }
}
