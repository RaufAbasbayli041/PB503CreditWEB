using AutoMapper;
using CredidSystem.Entity;
using CredidSystem.Models;

namespace CredidSystem.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<MerchantViewModel, Merchant>().ReverseMap();
            CreateMap<BranchViewModel, Branch>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<ProductViewModel, Product>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // если Id заполняется БД
           .ReverseMap()
           .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
           .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name));
        }
    }
}
