using System;
using System.ComponentModel.DataAnnotations;

namespace Payment.ViewModels
{
    public class SaleItemViewModel
    {

        public DateTime DateSaleItem { get; set; }

        [Required(ErrorMessage = "Informe a quantidade")]
        [Range(1,1000, ErrorMessage = "Quantidade deve ser entre 1 e 1000")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Informe o valor do item")]
        public decimal valueItem { get; set; }
        public ItemViewModel Item { get; set; }
    }
}
