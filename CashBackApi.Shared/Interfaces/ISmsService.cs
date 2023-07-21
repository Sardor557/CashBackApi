using CashBackApi.Shared.ViewModels;
using System.Threading.Tasks;

namespace CashBackApi.Shared.Interfaces
{
    public interface ISmsService
    {
        ValueTask<AnswerBasic> SendSmsAsync(viSms sms);
        ValueTask<AnswerBasic> ConfirmSmsAsync(viSms sms);
    }
}
