using AutoMapper;
using Hubtel.Wallets.Api.Dtos;
using Hubtel.Wallets.Api.Models;

namespace Hubtel.Wallets.Api.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletModel, WalletReadDto>();
            CreateMap<WalletCreateDto, WalletModel>();
        }
    }
}
