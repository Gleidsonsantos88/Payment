using System;
using System.Collections.Generic;

namespace PaymentService.Models
{
    public class Sale : Entity
    {
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }

        public DateTime DateSale { get; set; }

        public StatusSale StatusSale { get; set; }

        public IEnumerable<SaleItem> SaleItem { get; set; }
    }
}
