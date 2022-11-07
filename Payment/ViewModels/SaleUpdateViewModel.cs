using System;

namespace Payment.ViewModels
{
    public class SaleUpdateViewModel
    {
        public Guid Id { get; set; } 
        public StatusSaleViewModel StatusSale { get; set; }
    }
}
