using PaymentService.Models;
using System;
using System.Collections.Generic;

namespace PaymentTest.Builders
{
    public class SaleBuilder
    {
        private readonly Sale _intance;

        public SaleBuilder()
        {
            _intance = new Sale
            {
                 DateSale = DateTime.Now,
                 Id = Guid.NewGuid(),
                 StatusSale = StatusSale.AguardandoPagamento,
                 SaleItem = new List<SaleItem>
                 {
                     new SaleItem
                     {
                        Amount = 2,
                        DateSaleItem = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Item = new Item
                        {
                            Id = Guid.NewGuid(), 
                            Name = "Cadeira",
                            ValueItem = 800
                        }
                     },
                     new SaleItem
                     {
                        Amount = 1,
                        DateSaleItem = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Item = new Item
                        {
                            Id = Guid.NewGuid(),
                            Name = "Mesa",
                            ValueItem = 800
                        }
                     }
                 },
                 Seller = new Seller 
                 {
                    CPF = "09592373644",
                    Email = "gleidsonsantos88@outlook.com",
                    Id = Guid.NewGuid(),
                    Name ="Gleidson",
                    Telephone ="31991518842",
                 }
            };
        }

        public Sale Build()
        {
            return _intance;
        }

        public Sale SaleWithoutItem()
        {
            _intance.SaleItem = null;
            return _intance;
        }
    }
}
