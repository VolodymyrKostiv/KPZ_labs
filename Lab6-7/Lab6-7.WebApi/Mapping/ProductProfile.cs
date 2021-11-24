using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lab6_7.BLL.Dtos;
using Lab6_7.WebApi.ViewModels;

namespace Lab6_7.WebApi.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
        }
    }
}
