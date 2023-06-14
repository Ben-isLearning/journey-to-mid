using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public void UpdateLowStock()
        {
            if (AmountInStock < StockThreshold)
            {
                IsBelowStockThreshold = true;
            }
        }

        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }

    }
}
