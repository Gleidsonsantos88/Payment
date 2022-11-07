using System;
using System.Collections.Generic;

namespace Payment.ViewModels
{
    public class SaleViewModel
    {
        public SellerViewModel Seller { get; set; }

        public DateTime DateSale { get; set; }
        public IEnumerable<SaleItemViewModel> SaleItem { get; set; }
    }
}
