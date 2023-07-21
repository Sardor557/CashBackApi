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
    [SwaggerTag("SMS")]

    public class SmsController
    {
        private readonly ISmsService service;

        public SmsController(ISmsService service) => this.service = service;

        [HttpPost("send")]
        public ValueTask<AnswerBasic> SendSmsAsync(viSms sms) => service.SendSmsAsync(sms);

        [HttpPost("confirm")]
        public ValueTask<AnswerBasic> ConfirmSmsAsync(viSms sms) => service.ConfirmSmsAsync(sms);
    }
}
