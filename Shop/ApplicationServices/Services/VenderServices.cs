using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.ApplicationServices.IServices;
using Shop.Context;
using Shop.DTOs.Tags;
using Shop.DTOs.Vander;
using Shop.Inferastructure.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class VenderServices : IVanderService
    {
        private static List<Vender> venders=new List<Vender>();
        private readonly IVenderRepository _repository;
        private readonly IVanderService _vanderService;
        private readonly IMapper _mapper;
        public VenderServices(IVenderRepository repository,IVanderService vanderService,IMapper mapper)
        {
            _repository = repository;
            _vanderService = vanderService;
            _mapper = mapper;
        }
        public async Task<ServicesResponse<VanderListDTO>> GetById(int Id)
        {
            ServicesResponse<VanderListDTO> servicesResponse = new ServicesResponse<VanderListDTO>();
            servicesResponse.Data = _mapper.Map<VanderListDTO>(venders.FirstOrDefault(d => d.Id == Id));
            return servicesResponse;
        }
        public async Task<ServicesResponse<List<VanderListDTO>>> Insert(AddVendorListDTO vender)
        {
            ServicesResponse<List<VanderListDTO>> servicesResponse = new ServicesResponse<List<VanderListDTO>>();
            Vender vender1 =_mapper.Map<Vender>(venders);
            vender1.Id = venders.Max(c => c.Id) + 1;
            venders.Add(vender1);
            servicesResponse.Data = (venders.Select(c=>_mapper.Map<VanderListDTO>(c))).ToList();
            return servicesResponse;
        }
        public async Task<ServicesResponse<VanderListDTO>> Update(UpdateVenderDTO venderDTO)
        {
            ServicesResponse<VanderListDTO> servicesResponse = new ServicesResponse<VanderListDTO>();
            try
            {
                Vender vender = venders.FirstOrDefault(c => c.Id == venderDTO.Id);
                vender.Name = venderDTO.Name;
                vender.Title = venderDTO.Title;
                vender.Tags = venderDTO.Tags;
                vender.Date = venderDTO.Date;

                servicesResponse.Data = _mapper.Map<VanderListDTO>(vender);
            }
            catch (Exception ex)
            {
                servicesResponse.Success = false;
                servicesResponse.Message = ex.Message;
            }
            return servicesResponse;
        }
        public async Task<ServicesResponse<List<VanderListDTO>>> Delete(int Id)
        {
            ServicesResponse<List<VanderListDTO>> servicesResponse = new ServicesResponse<List<VanderListDTO>>();
            try
            {
                Vender vender = venders.First(c => c.Id == Id);
                venders.Remove(vender);
                servicesResponse.Data = (venders.Select(c => _mapper.Map<VanderListDTO>(c))).ToList();
            }
            catch (Exception ex)
            {
                servicesResponse.Success = false;
                servicesResponse.Message = ex.Message;
            }
            return servicesResponse;
        }
    }
}
