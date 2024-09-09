using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R.I.S.DAL.Models;
using R.I.S.BLL.DTO;
namespace R.I.S.BLL.Services
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper() 
        {
            CreateMap<Brand,BrandDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Review,ReviewDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
        }   
    }
}