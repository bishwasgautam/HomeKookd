﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HomeKookd.API.Filters;
using HomeKookd.DataAccess.HomeKookdAppIdentityContext.Entities;
using HomeKookd.Services;
using HomeKookd.Services.DTOs;
using HomeKookd.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HomeKookd.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IConfigurationRoot _configurationRoot;
        private readonly ILogger<AuthController> _logger;
        private readonly IHostingEnvironment _env;

        public AuthController(IAuthService authService, IUserService userService, IConfigurationRoot configurationRoot, ILogger<AuthController> logger, IHostingEnvironment env)
        {
            _authService = authService;
            _userService = userService;
            _configurationRoot = configurationRoot;
            _logger = logger;
            _env = env;
        }

        
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            //TODO remove this
            if (_env.IsDevelopment())
            {
              dto = new RegisterDto
              {
                  FirstName = "Bishwas",
                  LastName = "Gautam",
                  BirthDate = new DateTime(1988, 7, 26, 11,15,45),
                  Email = "bishwasgautam05@gmail.com",
                  Password = "TestPass123",
                  PhoneNumber = "12244502609",
                  UserName = "bishwasgautam05@gmal.com",
                  ImageUrl = "https://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/A-G/chimpanzee-with-baby.ngsversion.1412621761167.adapt.1900.1.jpg"
              };
            }

            IActionResult result = BadRequest();

            if (ModelState.IsValid)
            {
                _userService.Validate(dto);

                if (dto.IsValid)
                {
                    _userService.AddNewUser(dto);

                    var user = new AppUser()
                    {
                        UserName = dto.UserName,
                        Email = dto.Email,
                    };

                    var createUserResult = await _authService.CreateUserAsync(user, dto.Password);

                    if (createUserResult.Succeeded)
                    {
                        result = Ok(createUserResult);
                    }
                    else
                    {
                        createUserResult.Errors.ToList().ForEach(error =>
                            ModelState.AddModelError("error", error.Description)
                        );

                        result = BadRequest(createUserResult.Errors);
                    }
                }
                else
                {
                    result = BadRequest(dto.ValidationResult.Errors);
                }
            }

            return result;
        }

        [ValidateForm]
        [HttpPost("CreateToken")]
        [Route("token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto dto)
        {
            IActionResult result = Unauthorized();

            try
            {
                if (_userService.IsUserActive(dto))
                {
                    var user = await _authService.FindByNameAsync(dto.UserName);
                    if (user != null)
                    {
                        if (_authService.HasMatchingPassword(user, user.PasswordHash, dto.Password))
                        {
                            var userClaims = await _authService.GetClaimsAsync(user);
                            var claims = new[]
                            {
                                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Email, user.Email)
                            }.Union(userClaims);

                            var symmetricSecurityKey =
                                new SymmetricSecurityKey(
                                    Encoding.UTF8.GetBytes(_configurationRoot["JwtSecurityToken:Key"]));
                            var signingCredentials =
                                new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                            var jwtSecurityToken = new JwtSecurityToken(
                                issuer: _configurationRoot["JwtSecurityToken:Issuer"],
                                audience: _configurationRoot["JwtSecurityToken:Audience"],
                                claims: claims,
                                expires: DateTime.UtcNow.AddMinutes(60),
                                signingCredentials: signingCredentials
                            );

                            result = Ok(new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                                expiration = jwtSecurityToken.ValidTo
                            });
                        }
                    }
                };
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating token: {ex}");
                result = StatusCode((int)HttpStatusCode.InternalServerError, "error while creating token");
            }

            return result;
        }
    }
   
}