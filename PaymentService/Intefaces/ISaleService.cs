using PaymentService.Models;
using System;
using System.Threading.Tasks;

namespace PaymentService.Intefaces
{
    public interface ISaleService
    {
        Task<Guid> Add(Sale sale);
        Task<Sale> GetById(Guid saleId);
        Task Update(Sale sale);
    }
}
