using System.Collections.Generic;

namespace PaymentService.Models
{
    public class Seller : Entity
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
    }
}
