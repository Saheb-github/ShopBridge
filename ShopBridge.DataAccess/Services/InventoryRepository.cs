using Dapper;
using Microsoft.Extensions.Configuration;
using ShopBride.BussinessEntities.Models;
using ShopBridge.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ShopBridge.DataAccess.Services
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection db;
        public InventoryRepository(IConfiguration config)
        {
            _config = config;
            var connectionString = _config.GetSection("App:Connection:DefaultConnection").Value;
            db = new SqlConnection(connectionString);
        }

        public List<Inventory> GetAll()
        {
            string query = "select * from Inventory";
            return (List<Inventory>)db.Query<Inventory>(query);
        }

        public bool UpdateInventoryItem(Inventory inventoryItem)
        {
            int rowsAffected = this.db.Execute(
                        "UPDATE [Inventory] SET [ProductName]=@ProductName,ProductCode=@ProductCode,Description=@Description,UnitOfMeasureId=@UnitOfMeasureId, DefaultBuyingPrice=@DefaultBuyingPrice, DefaultSellingPrice=@DefaultSellingPrice WHERE ProductId= " + inventoryItem.ProductId,
                        inventoryItem);

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteteInventoryItem(int productId)
        {
            int rowsAffected = this.db.Execute(@"DELETE FROM [Inventory] WHERE ProductId = @ProductId",
                new { ProductId = productId });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public bool AddInventoryItem(Inventory inventory)
        {
            int rowsAffected = this.db.Execute(@"INSERT Inventory([ProductName],[ProductCode],[Description],[UnitOfMeasureId],[DefaultBuyingprice],[DefaultSellingPrice]) values (@ProductName, @ProductCode, @Description,@UnitOfMeasureId,@DefaultBuyingprice,@DefaultSellingPrice)",
                new { ProductName = inventory.ProductName, ProductCode = inventory.ProductCode, Description = inventory.Description, UnitOfMeasureId = inventory.UnitOfMeasureId, DefaultBuyingprice = inventory.DefaultBuyingPrice, DefaultSellingPrice = inventory.DefaultSellingPrice });
            
            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
