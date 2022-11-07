using AutoMapper;
using Payment.ViewModels;
using PaymentService.Models;

namespace Payment.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Sale, SaleViewModel>().ReverseMap();
            CreateMap<Sale, SaleGetByIdViewModel>().ReverseMap();
            CreateMap<Sale, SaleUpdateViewModel>().ReverseMap();

            CreateMap<Seller, SellerViewModel>().ReverseMap();
            CreateMap<Seller, SellerGetByIdViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<SaleItem, SaleItemViewModel>().ReverseMap();
            CreateMap<StatusSale, StatusSaleViewModel>().ReverseMap();
        }
    }
}
