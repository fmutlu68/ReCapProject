using Business.Abstract;
using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, string message = null)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user,claims.Data);
            if (message != null)
            {
                return new SuccessDataResult<AccessToken>(message, token);
            }
            return new SuccessDataResult<AccessToken>(Messages.GetAccessTokenCreatedSuccess,token);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>($"{ErrorCodes.GetNotFoundErrorCode} {ErrorMessages.GetAuthNotFoundEmailError}");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(ErrorMessages.GetAuthPasswordError);
            }
            return new SuccessDataResult<User>("Giriş Başrılı", userToCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                Email = userForRegisterDto.Email,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            IResult result = _userService.Add(user);
            if (result.Success)
            {
                return new SuccessDataResult<User>(Messages.GetAuthRegisteredSuccess, user);
            }
            return new ErrorDataResult<User>("Kayıt Olma İşlemi Başarısız",user);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(ErrorMessages.GetAuthEmailAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
