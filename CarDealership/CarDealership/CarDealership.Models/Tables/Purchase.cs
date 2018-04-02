using CarDealership.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int ListingId { get; set; }
        public int StateId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public PaymentOption PaymentOption { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
