using Moq;
using PaymentService.Intefaces;
using PaymentService.Models;
using PaymentService.Services;
using PaymentTest.Builders;
using System;
using Xunit;

namespace PaymentTest
{
    public class SaleServiceTest
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly ISaleService _saleService;
        public SaleServiceTest()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _saleService = new SaleService(_saleRepositoryMock.Object);
        }


        [Fact]
        public void Create_Sale_Success()
        {
            //Arrage
            var sale = new SaleBuilder().Build();
            _saleRepositoryMock.Setup(repository => repository.Add(sale))
                               .ReturnsAsync(sale.Id);

            //Act
            var response = _saleService.Add(sale);

            //Assert
            Assert.Equal(sale.Id.ToString(), response.Result.ToString());
        }

        [Fact]
        public void Create_Sale_Without_Item()
        {
            //Arrage
            var sale = new SaleBuilder().SaleWithoutItem();
            string mensagem = "Informe pelo menos 1 item.";

            //Act
            var response = _saleService.Add(sale);

            //Assert
            Assert.Equal(mensagem, response.Exception.InnerException.Message);
        }

        [Fact]
        public async void Create_Sale_Exception()
        {
            //Arrage
            var sale = new SaleBuilder().Build();
            _saleRepositoryMock.Setup(repository => repository.Add(sale))
                              .ReturnsAsync(sale.Id);

            string mensagem = "Ocorreu um erro ao tentar cadastrar uma venda, entre em contato com o administrador.";

            Exception exception  = await Assert.ThrowsAsync<Exception>(() => _saleService.Add(null));
            //Assert
            Assert.Equal(exception.Message, mensagem);
        }

        [Theory]
        [InlineData(StatusSale.Cancelada)]
        [InlineData(StatusSale.Entregue)]
        [InlineData(StatusSale.EnviadoParaTransportadora)]
        [InlineData(StatusSale.PagamentoAprovado)]
        public void Create_Sale_Status_Different_Awaiting_Payment_Error(StatusSale status)
        {
            //Arrage
            var sale = new SaleBuilder().Build();
            string mensagem = "Venda só pode ser criada com status (Aguardando pagamento).";
            sale.StatusSale = status;

            //Act
            var response = _saleService.Add(sale);

            //Assert
            Assert.Equal(mensagem, response.Exception.InnerException.Message);
        }

        [Theory]
        [InlineData(StatusSale.PagamentoAprovado)]
        [InlineData(StatusSale.Cancelada)]
        public void Update_Sale_Status_Allowed_Success(StatusSale status)
        {
            //Arrage
            var sale = new SaleBuilder().Build();
            var newSale = new SaleBuilder().Build();
            newSale.StatusSale = status;

            _saleRepositoryMock.Setup(repository => repository.GetById(newSale.Id))
                               .ReturnsAsync(sale);

            //Act
            var response = _saleService.Update(newSale);

            //Assert
            Assert.True(response.Exception == null);
        }

        [Theory]
        [InlineData(StatusSale.EnviadoParaTransportadora)]
        [InlineData(StatusSale.Entregue)]
        public void Update_Sale_Status_Different_Allowed_Error(StatusSale status)
        {
            //Arrage
            var sale = new SaleBuilder().Build();
            var newSale = new SaleBuilder().Build();
            string mensagem = "Status não pode ser usado.";
            newSale.StatusSale = status;

            _saleRepositoryMock.Setup(repository => repository.GetById(newSale.Id))
                               .ReturnsAsync(sale);

            //Act
            var response = _saleService.Update(newSale);

            //Assert
            Assert.Equal(mensagem, response.Exception.InnerException.Message);
        }

        [Fact]
        public void Update_Sale_Not_Exist_Error()
        {
            //Arrage
            Sale sale = new Sale();
            var newSale = new SaleBuilder().Build();
            string mensagem = "Venda não localizada.";

            _saleRepositoryMock.Setup(repository => repository.GetById(sale.Id))
                               .ReturnsAsync(sale);

            //Act
            var response = _saleService.Update(newSale);

            //Assert
            Assert.Equal(mensagem, response.Exception.InnerException.Message);
        }

        [Fact]
        public void GetById_Sale_Success()
        {
            //Arrage
            Sale sale = new SaleBuilder().Build();

            _saleRepositoryMock.Setup(repository => repository.GetById(sale.Id))
                               .ReturnsAsync(sale);

            //Act
            var response = _saleService.GetById(sale.Id);

            //Assert
            Assert.Equal(sale, response.Result);
        }
    }
}
