using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurtityToken(_tokenOptions, user,signingCredentials,operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken {Token = token,Expiration = _accessTokenExpiration };

        }
        public JwtSecurityToken CreateJwtSecurtityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                claims: SetClaims(operationClaims,user),
                signingCredentials: signingCredentials,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                audience: tokenOptions.Audience
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(List<OperationClaim> claims, User user)
        {
            var createdClaims = new List<Claim>();
            createdClaims.AddEmail(user.Email);
            createdClaims.AddName($"{user.FirstName} {user.LastName}");
            createdClaims.AddNameIdentifier(user.Id.ToString());
            createdClaims.AddRoles(claims.Select(c=>c.Name).ToArray());
            return createdClaims;
        }
    }
}
