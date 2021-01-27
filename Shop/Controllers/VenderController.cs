using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.IServices;
using Shop.ApplicationServices.Services;
using Shop.DTOs.Vander;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenderController : ControllerBase
    {
        private readonly List<Vender> venders;
        private readonly IMapper _mapper;
        private readonly IVanderService _VanderService;
        public VenderController(IVanderService vanderService,IMapper mapper)
        {
            _VanderService = vanderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _VanderService.GetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Insert(AddVendorListDTO DTO)
        {
            return Ok(await _VanderService.Insert(DTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateVenderDTO DTO)
        {
            ServicesResponse<VanderListDTO> response = await _VanderService.Update(DTO);
            if (response.Data==null)
            {
                return NotFound(response);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServicesResponse<List<VanderListDTO>> response = await _VanderService.Delete(id);
            if (response.Data==null)
            {
                return NotFound(response);
            }
            return Ok();
        }
        [HttpPatch("id")]
        public IActionResult Patch(int id, JsonPatchDocument<UpdateVenderDTO> DTO)
        {
            var result = _VanderService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var Patch = _mapper.Map<UpdateVenderDTO>(result);

            DTO.ApplyTo(Patch, ModelState);

            _mapper.Map(Patch, result);

            return Ok(_mapper.Map<UpdateVenderDTO>(result));
        }
    }
}
