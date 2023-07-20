﻿using CashBackApi.Shared.Interfaces;
using CashBackApi.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CashBackApi.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [SwaggerTag("Пользователи")]

    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service) => this.service = service;

        [AllowAnonymous]
        [HttpPost("login")]
        public ValueTask<Answer<viUser>> AuthenticateAsync([FromBody] viAuthenticateModel model)
        {
            var ip = this.Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            return service.AuthenticateAsync(model, ip);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public ValueTask<Answer<viUser>> CreateUserAsync([FromBody] viUserCreate create) => service.CreateUserAsync(create);
    }
}