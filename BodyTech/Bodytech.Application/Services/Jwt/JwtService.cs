using Bodytech.Application.Common.Const;
using Bodytech.Application.Models.Token;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bodytech.Application.Services.Jwt
{
    /// <summary>
    /// Classe que gera os tokens jwt para auth
    /// </summary>
    public class JwtService : IJwtService
    {
        private JwtSecurityTokenHandler TokenHandler;
        private string JwtKey;

        public JwtService()
        {
            TokenHandler = new JwtSecurityTokenHandler();
            JwtKey = ConfigurationManager.AppSettings["jwt.key"];
        }

        /// <summary>
        /// Metodo que gera um token JWT 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public string CreateToken(int userId, string username, IEnumerable<int> roles)
        {
            string issuer = Domain.CurrentDomain;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim("username", username));
            claimsIdentity.AddClaim(new Claim("user_id", userId.ToString()));
            claimsIdentity.AddClaim(new Claim("roles", JsonConvert.SerializeObject(roles)));

            JwtSecurityToken jwtSecurityToken = TokenHandler.CreateJwtSecurityToken(issuer, string.Empty, claimsIdentity, null, DateTime.Now.AddHours(5), DateTime.Now, credentials);
            return TokenHandler.WriteToken(jwtSecurityToken);
        }

        public JwtTokenModel ReadToken(string token)
        {
            if (ValidateToken(token))
            {
                var securityToken = TokenHandler.ReadJwtToken(token);
                var username = securityToken.Payload["username"].ToString();
                var user_id = securityToken.Payload["user_id"].ToString();
                var roles = JsonConvert.DeserializeObject<IEnumerable<int>>(securityToken.Payload["roles"].ToString());

                return new JwtTokenModel
                {
                    Username = username,
                    UserId = user_id,
                    Roles = roles
                };
            }
            else
            {
                throw new Exception(ExceptionMessages.TokenInvalido);
            }
        }

        /// <summary>
        /// Metodo que valida se o token JWT ainda e valido.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool ValidateToken(string token)
        {
            try
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Domain.CurrentDomain,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };

                TokenHandler.ValidateToken(token, validationParameters, out var securityToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}