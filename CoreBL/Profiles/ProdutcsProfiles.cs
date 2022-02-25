using AutoMapper;
using CoreBL.Models;
using CoreDAL.Entities;
using System;

namespace CoreBL.Profiles
{
    public class ProdutcsProfiles : Profile
    {
        public ProdutcsProfiles()
        {
            CreateMap<Product, ProductDTO>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
             .ForMember(dest => dest.ArrivedDate, opt => opt.MapFrom(src => DateTime.Parse(src.ArrivedDate)));

            CreateMap<ProductDTO, Product>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
              .ForMember(dest => dest.ArrivedDate, opt => opt.MapFrom(src => src.ArrivedDate.ToString()));
        }
    }
}
