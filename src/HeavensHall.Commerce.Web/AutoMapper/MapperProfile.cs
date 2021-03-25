using AutoMapper;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Web.Models;

namespace HeavensHall.Commerce.Web.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StockModel, Stock>()
                        .ReverseMap();

            CreateMap<ProductImage, ProductImageModel>()
                        .ReverseMap();

            CreateMap<Stock, ProductDTO>()
                        .ReverseMap()
                        .ForMember(dest => dest.Id, src => src.MapFrom(p => p.Stock_Id))
                        .ForMember(dest => dest.Quantity, src => src.MapFrom(p => p.Quantity))
                        .ForPath(dest => dest.Product.Description, src => src.MapFrom(p => p.Description))
                        .ForPath(dest => dest.Product.Brand.Id, src => src.MapFrom(p => p.Brand_Id))
                        .ForPath(dest => dest.Product.Brand.Name, src => src.MapFrom(p => p.Brand_Name))
                        .ForPath(dest => dest.Product.Category.Id, src => src.MapFrom(p => p.Category_Id))
                        .ForPath(dest => dest.Product.Category.Name, src => src.MapFrom(p => p.Category_Name));

            CreateMap<ProductModel, Product>()
                        .ReverseMap()
                        .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Name))
                        .ForMember(dest => dest.Description, src => src.MapFrom(p => p.Description))
                        .ForMember(dest => dest.Id, src => src.MapFrom(p => p.Id))
                        .ForMember(dest => dest.Description, src => src.MapFrom(p => p.Description))
                        .ForMember(dest => dest.Price, src => src.MapFrom(p => p.Price))
                        .ForPath(dest => dest.Brand.Id, src => src.MapFrom(p => p.Brand.Id))
                        .ForPath(dest => dest.Brand.Name, src => src.MapFrom(p => p.Brand.Name))
                        .ForPath(dest => dest.Category.Name, src => src.MapFrom(p => p.Category.Name))
                        .ForPath(dest => dest.Category.Id, src => src.MapFrom(p => p.Category.Id));

            CreateMap<ProductModel, ProductDetail>()
                        .ReverseMap()
                        .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Product.Name))
                        .ForMember(dest => dest.Description, src => src.MapFrom(p => p.Product.Description))
                        .ForMember(dest => dest.Id, src => src.MapFrom(p => p.Product.Id))
                        .ForMember(dest => dest.Price, src => src.MapFrom(p => p.Product.Price))
                        .ForPath(dest => dest.Brand.Id, src => src.MapFrom(p => p.Product.Brand.Id))
                        .ForPath(dest => dest.Brand.Name, src => src.MapFrom(p => p.Product.Brand.Name))
                        .ForPath(dest => dest.Category.Name, src => src.MapFrom(p => p.Product.Category.Name))
                        .ForPath(dest => dest.Category.Id, src => src.MapFrom(p => p.Product.Category.Id));

            CreateMap<ProductDetail, ProductDTO>()
                        .ReverseMap()
                        .ForMember(dest => dest.Color, src => src.MapFrom(p => p.Color))
                        .ForMember(dest => dest.Rating, src => src.MapFrom(p => p.Rating))
                        .ForPath(dest => dest.Product.Name, src => src.MapFrom(p => p.Product_Name))
                        .ForPath(dest => dest.Product.Description, src => src.MapFrom(p => p.Description))
                        .ForPath(dest => dest.Product.Brand.Id, src => src.MapFrom(p => p.Brand_Id))
                        .ForPath(dest => dest.Product.Brand.Name, src => src.MapFrom(p => p.Brand_Name))
                        .ForPath(dest => dest.Product.Category.Id, src => src.MapFrom(p => p.Category_Id))
                        .ForPath(dest => dest.Product.Is_Active, src => src.MapFrom(p => p.Is_Active))
                        .ForPath(dest => dest.Product.Category.Name, src => src.MapFrom(p => p.Category_Name));

            CreateMap<ProductDTO, ProductModel>()
                        .ReverseMap()
                        .ForMember(dest => dest.Color, src => src.MapFrom(p => p.Color))
                        .ForMember(dest => dest.Is_Active, src => src.MapFrom(p => p.Is_Active))
                        .ForMember(dest => dest.Rating, src => src.MapFrom(p => p.Rating))
                        .ForMember(dest => dest.Product_Id, src => src.MapFrom(p => p.Id))
                        .ForMember(dest => dest.Product_Name, src => src.MapFrom(p => p.Name))
                        .ForMember(dest => dest.Description, src => src.MapFrom(p => p.Description))
                        .ForMember(dest => dest.Brand_Id, src => src.MapFrom(p => p.Brand.Id))
                        .ForMember(dest => dest.Brand_Name, src => src.MapFrom(p => p.Brand.Name))
                        .ForMember(dest => dest.Category_Id, src => src.MapFrom(p => p.Category.Id))
                        .ForMember(dest => dest.Category_Name, src => src.MapFrom(p => p.Category.Name))
                        .ForMember(dest => dest.Stock_Id, src => src.MapFrom(p => p.Stock.Id))
                        .ForMember(dest => dest.Quantity, src => src.MapFrom(p => p.Stock.Quantity));
        }
    }
}
