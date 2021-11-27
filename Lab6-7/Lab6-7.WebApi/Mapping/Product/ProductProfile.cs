using AutoMapper;
using Lab6_7.BLL.DTOs.Product;
using Lab6_7.DataAccess.Models.Product;
using Lab6_7.WebApi.ViewModels;

namespace Lab6_7.WebApi.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
            CreateMap<ProductModel, ProductDTO>().ReverseMap();
        }
    }
}
