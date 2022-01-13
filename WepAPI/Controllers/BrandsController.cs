using Business.Abstract;
using Entities.Concentre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("add")]
        public IActionResult Add(Brand user)
        {
            var result = _brandService.Add(user);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Brand user)
        {
            var result = _brandService.Delete(user);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Updated(Brand user)
        {
            var result = _brandService.Update(user);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbrandid")]
        public IActionResult GetBrandId(int id)
        {
            var result = _brandService.GetBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbrandname")]
        public IActionResult GetbyName(string name)
        {
            var result = _brandService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
