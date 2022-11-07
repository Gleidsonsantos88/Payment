using System;
using System.Collections.Generic;

namespace Payment.ViewModels
{
    public class SaleGetByIdViewModel
    {
        public Guid Id { get; set; }
        public SellerGetByIdViewModel Seller { get; set; }

        public DateTime DateSale { get; set; }

        public StatusSaleViewModel StatusSale { get; set; }

        public IEnumerable<SaleItemViewModel> SaleItem { get; set; }
    }
}
