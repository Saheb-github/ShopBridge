using ShopBride.BussinessEntities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace ShopBridge.DataAccess.Interfaces
{
    public interface IInventoryRepository
    {
        List<Inventory> GetAll();

        bool UpdateInventoryItem(Inventory inventoryItem);
        bool AddInventoryItem(Inventory inventoryItem);
        bool DeleteteInventoryItem(int id);
    }
}
