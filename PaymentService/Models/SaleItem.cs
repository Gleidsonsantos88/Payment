using System;

namespace PaymentService.Models
{
    public class SaleItem : Entity
    {
        public DateTime DateSaleItem { get; set; }
        public int Amount { get; set; }
        public decimal valueItem { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }

        public Sale Sale { get; set; }
        public Guid SaleId { get; set; }
    }
}
