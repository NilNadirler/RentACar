using Business.Abstract;
using Core.Result;
using Entities.Concentre;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImagesService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImagesService, IWebHostEnvironment webHostEnvironment)
        {
            _carImagesService = carImagesService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImagesService.Add(carImage, file, _webHostEnvironment);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            

            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {

            var result = _carImagesService.Delete(carImage, _webHostEnvironment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result = _carImagesService.Update(carImage, file, _webHostEnvironment);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);

        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImagesService.GetByCarID(carId);
            foreach (var item in result.Data)
            {
                var imageResult = _carImagesService.GetBase64(item.ImagePath, _webHostEnvironment);
                result.Data.Find(image => image == item).ImagePath = "data:image/png;base64," + imageResult.Data;
            }
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
