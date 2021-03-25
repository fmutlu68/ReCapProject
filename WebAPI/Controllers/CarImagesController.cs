using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
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

        [HttpPost("getall")]
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
        public IActionResult GetById([FromForm(Name = ("Id"))] int Id)
        {
            var result = _carImageService.Get(Id, "Araba Resmi");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] FileAddUpload fileUpload)
        {
            CarImage carImage = JsonConvert.DeserializeObject<CarImage>(fileUpload.carImage);
            var result = _carImageService.AddImage(carImage, fileUpload.fileImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImage = _carImageService.Get(Id, "Araba Resmi").Data;

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] FileUpdateUpload fileUpdateUpload)
        {
            var carImage = _carImageService.Get(fileUpdateUpload.Id, "Araba Resmi").Data;

            var result = _carImageService.UpdateImage(carImage, fileUpdateUpload.fileImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
    public class FileAddUpload
    {
        public string carImage { get; set; }
        public IFormFile fileImage { get; set; }
    }
    public class FileUpdateUpload
    {
        public int Id { get; set; }
        public IFormFile fileImage { get; set; }
    }
}
