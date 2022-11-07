using PaymentService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PaymentService.Utils
{
    public class StatusFactory
    {
        private static Dictionary<int, List<int>> statusSale = new Dictionary<int, List<int>>();
        static StatusFactory()
        {
            statusSale.Add((int)StatusSale.AguardandoPagamento, new List<int>()
            {
                (int)StatusSale.PagamentoAprovado,
                (int)StatusSale.Cancelada
            });

            statusSale.Add((int)StatusSale.PagamentoAprovado, new List<int>()
            {
                (int)StatusSale.EnviadoParaTransportadora,
                (int)StatusSale.Cancelada
            });

            statusSale.Add((int)StatusSale.EnviadoParaTransportadora, new List<int>()
            {
                (int)StatusSale.Entregue
            });
        }
        public static bool StatusValid(int status, int newStatus)
        {
            var statusValid = statusSale[status];

            if (statusValid.Count > 0)
            {
                if (!statusValid.Any(x => x == newStatus))
                    return false;
            }

            return true;
        }

    }
}
