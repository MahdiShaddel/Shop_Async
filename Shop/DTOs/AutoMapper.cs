using AutoMapper;
using Shop.DTOs.Vander;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DTOs
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Vender, VanderListDTO>();
            CreateMap<AddVendorListDTO, Vender>();
        }
    }
}
