using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Style_Sample
{
    public class OrderInfo
    {
        int orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;

        [Display (Name ="Order ID")]
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        [Display(Name = "Customer ID")]

        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }

        [Display(Name = "Customer Name")]

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        [Display(Name = "Ship City")]

        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; }
        }

        public OrderInfo(int orderId, string customerName, string country, string customerId, string shipCity)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
        }
    }
}
