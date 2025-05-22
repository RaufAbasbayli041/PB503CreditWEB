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
            CreateMap<ProductViewModel, Product>().ForMember(x=>x.Category,opt=>opt.MapFrom(x=>x.CategoryName)).ForMember(y=>y.Branch,opt=> opt.MapFrom(x=>x.BranchName)).ReverseMap();

        }
    }
}
