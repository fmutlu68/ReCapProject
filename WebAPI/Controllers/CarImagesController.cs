using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        [Authorize()]
        public IActionResult GetAll()
        {
            IDataResult<List<CarImage>> result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        [Authorize()]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetAllImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        [Authorize()]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _carImageService.Get(id, "Araba Resmi");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        [Authorize()]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile image, [FromForm(Name = ("Car"))] string car)
        {
            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(car);
            var result = _carImageService.AddImage(carImage, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        [Authorize()]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {

            var result = _carImageService.DeleteImage(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        [Authorize()]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile fileImage, [FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageService.Get(id, "Araba Resmi").Data;

            var result = _carImageService.UpdateImage(carImage, fileImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
