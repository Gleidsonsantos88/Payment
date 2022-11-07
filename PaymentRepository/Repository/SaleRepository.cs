using PaymentService.Intefaces;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentRepository.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private static List<Sale> sales = new List<Sale>();

        public async Task<Guid> Add(Sale sale)
        {
            sales.Add(sale);
            return await Task.Run(() => sale.Id);
        }

        public async Task<Sale> GetById(Guid saleId)
        {
            return await Task.Run(() => sales.FirstOrDefault(x => x.Id == saleId));
        }

        public async Task Update(Sale sale)
        {
           await Task.Run(() => sales.FirstOrDefault(x => x.Id == sale.Id).StatusSale = sale.StatusSale);
        }
    }
}
