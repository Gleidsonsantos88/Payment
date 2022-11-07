using System.ComponentModel;

namespace Payment.ViewModels
{
    public enum StatusSaleViewModel
    {
        [Description("Aguardando Pagamento")]
        AguardandoPagamento = 0,
        [Description("Pagamento Aprovado")]
        PagamentoAprovado = 1,
        [Description("Enviado Para Transportadora")]
        EnviadoParaTransportadora = 2,
        [Description("Entregue")]
        Entregue = 3,
        [Description("Cancelada")]
        Cancelada = 4
    }
}
