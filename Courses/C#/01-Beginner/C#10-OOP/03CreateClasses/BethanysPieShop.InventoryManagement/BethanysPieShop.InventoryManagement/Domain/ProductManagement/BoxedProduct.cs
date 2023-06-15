using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BoxedProduct : Product
    {
        public BoxedProduct(int id, string name, string? description, Price price, int maxAmountInStock, int amountPerBox)
            : base(id, name, description, price, UnitType.PerBox, maxAmountInStock)
        {
            AmountPerBox = amountPerBox;
        }

        private int amountPerBox;
        public int AmountPerBox
        {
            get { return amountPerBox; }
            set
            {
                amountPerBox = value;
            }
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Boxed Product\n");
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");
            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }
            return sb.ToString();
        }

        public override void UseProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items) 
                { 
                    batchSize = smallestMultiple * AmountPerBox; 
                    break; 
                }
            }

            base.UseProduct(batchSize); //Use base Method
        }

        public override void IncreaseStock()
        {
            IncreaseStock(1);
        }

        public override void IncreaseStock(int amount)
        {

            //it is possible to call the base here too, but we are assuming that this is handled differently

            int newStock = AmountInStock + amount * AmountPerBox;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount * AmountPerBox;
            }
            else
            {
                AmountInStock = maxItemsInStock;//we only store the possible items, overstock isn't stored
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) order that couldn't be stored.");
            }

            if (AmountInStock > StockThreshold)
            {
                IsBelowStockThreshold = false;
            }
        }

    }
}
