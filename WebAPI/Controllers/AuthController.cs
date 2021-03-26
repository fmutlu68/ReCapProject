using Business.Abstract;
using Core.Utilities.Results;
using Entities.Dtos;
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
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (userToLogin.Success == false)
            {
                return BadRequest(userToLogin);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data,"Giriş İşlemi Başarılı");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (userExists.Success == false)
            {
                return BadRequest(userExists);
            }
            var userToRegister = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(userToRegister.Data, "Kayıt İşlemi Başarılı");
            if (userToRegister.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
