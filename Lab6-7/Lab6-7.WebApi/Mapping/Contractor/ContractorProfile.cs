using AutoMapper;
using Lab6_7.BLL.DTOs.Contractor;
using Lab6_7.WebApi.ViewModels;

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
