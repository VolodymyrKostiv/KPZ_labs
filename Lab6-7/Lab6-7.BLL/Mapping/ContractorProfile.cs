using AutoMapper;
using Lab6_7.BLL.Dtos;
using Lab6_7.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.BLL.Mapping
{
    class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<Contractor, ContractorDTO>().ReverseMap();
        }
    }
}
