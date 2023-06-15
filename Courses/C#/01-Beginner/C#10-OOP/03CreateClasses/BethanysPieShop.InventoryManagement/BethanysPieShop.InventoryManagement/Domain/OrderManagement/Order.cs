﻿using BethanysPieShop.InventoryManagement.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.OrderManagement
{
    public class Order: ISaveable, ICloneable
    {
        public int Id { get; private set; }
        public DateTime OrderFulfilmentDate { get; private set; }
        public List<OrderItem> OrderItems { get; }
        public bool Fulfilled { get; set; } = false;

        public Order()
        {
            Id = new Random().Next(999999);

            int numberOfSeconds = new Random().Next(100);
            OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

            OrderItems = new List<OrderItem>();
        }

        public string ShowOrderDetails()
        {
            StringBuilder orderDetails = new StringBuilder();

            orderDetails.AppendLine($"Order ID: {Id}");
            orderDetails.AppendLine($"Order fulfilment date: {OrderFulfilmentDate.ToShortTimeString()}");

            if (OrderItems != null)
            {
                foreach (OrderItem item in OrderItems)
                {
                    orderDetails.AppendLine($"{item.ProductId}. {item.ProductName}: {item.AmountOrdered}");

                }
            }

            return orderDetails.ToString();

        }

        public string ConvertToStringForSaving()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
