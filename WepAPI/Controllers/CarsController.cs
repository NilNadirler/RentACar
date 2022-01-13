using Business.Abstract;
using Business.Concentre;
using DataAccess.Concentre.EntityFramework;
using Entities.Concentre;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase

    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {


            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost("datatable")]
        public IActionResult Datatable(DataTableRequestDto<CarDetailDto> request)
        {
            CarDetailDto dto = request.GetEntity();
            var result = this._carService.GetDetails(null);
            DataTableResultDto<CarDetailDto> dataTableResultDto = new DataTableResultDto<CarDetailDto>();
            dataTableResultDto.Draw = request.Draw;
            dataTableResultDto.RecordsTotal = result.Data.Count;
            dataTableResultDto.RecordsFiltered = result.Data.Count;
            if (dto.BrandName!=null)
            {
                result = this._carService.GetDetailsByFilter(dto);
            }
            int len = (result.Data.Count > request.Start + request.Length) ? request.Length : result.Data.Count - request.Start;
            dataTableResultDto.Data = result.Data.GetRange(request.Start,len);
            return Ok(dataTableResultDto);
        }

        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetbyId(int id)
        {
            var result = _carService.GetbyID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);

        }
        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("dailyprice")]
        public IActionResult GetDailyPrice(decimal min, decimal max)
        {
            var result = _carService.GetByDailyPrice(min, max);
            {
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result);
            }
        }
        [HttpGet("carmodelyear")]
        public IActionResult ModelYear(int model)
        {
            var result = _carService.GetCarsModelYear(model);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColorID(int colorId)
        {
            var result = _carService.GetByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetails")]
        public IActionResult GetDetails(string brandName=null,string colorName=null)
        {
            var dto = new CarDetailDto();
            dto.BrandName = brandName;
            dto.ColorName = colorName;
            if (colorName == null && brandName == null) { dto = null; }
            var result = _carService.GetDetails(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
