using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.DTOs.Vander;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.IServices
{
    public interface IVanderService
    {
        Task<ServicesResponse<VanderListDTO>> GetById(int Id);
        Task<ServicesResponse<List<VanderListDTO>>> Insert(AddVendorListDTO vender);
        Task<ServicesResponse<VanderListDTO>> Update(UpdateVenderDTO venderDTO);
        Task<ServicesResponse<List<VanderListDTO>>> Delete(int Id);
    }
}
