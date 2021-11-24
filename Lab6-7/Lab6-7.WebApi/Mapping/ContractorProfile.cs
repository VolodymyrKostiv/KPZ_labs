using AutoMapper;
using Lab6_7.BLL.Dtos;
using Lab6_7.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6_7.WebApi.Mapping
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<ContractorDTO, ContractorViewModel>().ReverseMap();
        }
    }
}
