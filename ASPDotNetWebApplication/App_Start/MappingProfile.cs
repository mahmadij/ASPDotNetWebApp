using ASPDotNetWebApplication.Dtos;
using ASPDotNetWebApplication.Models;
using AutoMapper;

namespace ASPDotNetWebApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Item, ItemDTO>();
                CreateMap<ItemDTO, Item>();
        }
    }
}