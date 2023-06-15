using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshProduct : Product
    {
        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) :
            base(id, name, description, price, unitType, maxAmountInStock)
        { }

        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            sb.AppendLine($"Storage instructions: {StorageInstructions}");
            sb.AppendLine($"Expiry Date: {ExpiryDateTime.ToShortDateString()}");

            return sb.ToString();
        }

    }
}
