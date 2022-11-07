using PaymentService.Intefaces;
using PaymentService.Models;
using PaymentService.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Guid> Add(Sale sale)
        {
            try
            {
                if(sale.SaleItem == null || sale.SaleItem.ToList().Count == 0)
                    throw new ArgumentException("Informe pelo menos 1 item.");
                if (sale.StatusSale != StatusSale.AguardandoPagamento)
                    throw new ArgumentException("Venda só pode ser criada com status (Aguardando pagamento).");

                sale.StatusSale = StatusSale.AguardandoPagamento;
             
                return await _saleRepository.Add(sale);
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar cadastrar uma venda, entre em contato com o administrador.");
            }
        }

        public async Task<Sale> GetById(Guid saleId)
        {
            return await _saleRepository.GetById(saleId);
        }

        public async Task Update(Sale sale)
        {
            var saleUpdate = await _saleRepository.GetById(sale.Id);

            if(saleUpdate == null)
                throw new ArgumentException("Venda não localizada.");

            if (!StatusFactory.StatusValid((int)saleUpdate.StatusSale, (int)sale.StatusSale))
                throw new ArgumentException("Status não pode ser usado.");

            saleUpdate.StatusSale = sale.StatusSale;
             
            await _saleRepository.Update(sale);
        }
    }
}
