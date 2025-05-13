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
        }
    }
}
