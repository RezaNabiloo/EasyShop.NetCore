﻿using BSG.EasyShop.Application.Contracts.Identity;
using BSG.EasyShop.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSG.EasyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        { 
            return Ok(await _authService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationRequest>> Register (RegistrationRequest request)
        {
            return Ok(await  _authService.Register(request));
        }
    }
}
