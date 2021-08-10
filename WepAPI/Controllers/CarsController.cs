using Business.Abstract;
using Business.Concentre;
using DataAccess.Concentre.EntityFramework;
using Entities.Concentre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{ [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase

    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            //ICarService carService = new CarManager(new EfCarDal());

            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

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
            var result = _carService.GetByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
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
        [HttpGet("getcolorid")]
        
              public IActionResult GetColorID(int id)
        {
            var result = _carService.GetbyColarId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        
    }
}
