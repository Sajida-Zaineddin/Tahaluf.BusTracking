using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository loginRepository ;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public string Auth(Login login)
        {
            // return jwtRepository.Auth(login); ---> username & rolename (payload for token)
            var result = loginRepository.Auth(login);  // result = username &rolename

            if (result == null)
            {
                return null;
            }
            else
            {

                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("welcome to eqbal site"));

              
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                  
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       
                        new Claim(ClaimTypes.Name, result.Username),
                      
                         new Claim(ClaimTypes.Role ,result.Rolename)
                    }), 
                  
                    Expires = DateTime.UtcNow.AddHours(1), 

                   
                    SigningCredentials = new SigningCredentials(TokenKey, SecurityAlgorithms.HmacSha256Signature)

                };

                var token = TokenHandler.CreateToken(TokenDescriptor);

                return TokenHandler.WriteToken(token);

            }


        }
    }
}
