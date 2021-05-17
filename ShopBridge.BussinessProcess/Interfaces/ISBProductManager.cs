using ShopBride.BussinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.BussinessProcess.Interfaces
{
    public interface ISBProductManager
    {
        Task<List<Inventory>> GetInventoryDetails();
        Task<bool> IsInventoryItemUpdated(Inventory inventory);
        Task<bool> AddInventory(Inventory inventory);

        Task<bool> DeleteInventory(int id);
    }
}
