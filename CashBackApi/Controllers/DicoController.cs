using CashBackApi.Models;
using CashBackApi.Shared.Interfaces;
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
    [Route("[controller]")]
    [SwaggerTag("Дико")]

    public class DicoController
    {
        private readonly IDicoService service;

        public DicoController(IDicoService service) => this.service = service;

        [HttpGet("user_types")]
        public ValueTask<Answer<spUserType[]>> GetUserTypesAsync() => service.GetUserTypesAsync();

        [HttpGet("statuses")]
        public ValueTask<Answer<spStatus[]>> GetStatusesAsync() => service.GetStatusesAsync();
    }
}
