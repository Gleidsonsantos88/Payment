using System;

namespace Payment.ViewModels
{
    public class SellerGetByIdViewModel
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
