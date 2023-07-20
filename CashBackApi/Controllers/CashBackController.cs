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
    [Route("api/[controller]")]
    [SwaggerTag("Кешбек")]
    public class CashBackController
    {
        private readonly ICashBackService service;

        public CashBackController(ICashBackService service) => this.service = service;

        [HttpPost("change")]
        public ValueTask<AnswereBasic> ChangeCashbackAsync(viCashback cashback) => service.ChangeCashbackAsync(cashback);
    }
}
