using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshProduct : Product
    {
        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) :
            base(id, name, description, price, unitType, maxAmountInStock)
        { }

        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }
    }
}
