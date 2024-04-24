﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITIDB_.net_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login(string username,string password)
        {
            if(username == "admin" || password == "123")
            {
                //claims
                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim("username", "admin"));
                userdata.Add(new Claim(ClaimTypes.MobilePhone, "01016153398"));
                //secret key
                string key = "welcme to secret key mohamed abdou";
                SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                //signature
                SigningCredentials signcre = new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);

                //to generate token 
                //header => hashing algo  ==> already generated by default with package
                //payload => claims,expireDate
                //signature => secret key
                var token = new JwtSecurityToken(
                    claims:userdata,
                    expires:DateTime.Now.AddDays(1),
                    signingCredentials:signcre

                    
                    );

                //token object ==> encoded string
                var tokenobjhand = new JwtSecurityTokenHandler();
               var finaltoken =  tokenobjhand.WriteToken(token);
                return Ok(finaltoken);
            }

            else
            {
                return Unauthorized();
            }

        }
    }
}
