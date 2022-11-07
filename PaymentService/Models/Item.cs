using System.Collections.Generic;

namespace PaymentService.Models
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public decimal ValueItem { get; set; }

        public virtual IEnumerable<SaleItem> SaleItem { get; set; }
    }
}
