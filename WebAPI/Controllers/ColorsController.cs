﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        [Authorize()]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        [Authorize()]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        [Authorize()]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        [Authorize()]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        [Authorize()]
        public IActionResult GetById(int id)
        {
            var result = _colorService.Get(id, "Renk");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
