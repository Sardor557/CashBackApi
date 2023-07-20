using CashBackApi.Shared.ViewModels;
using System.Threading.Tasks;

namespace CashBackApi.Shared.Interfaces
{
    public interface ISmsService
    {
        ValueTask<AnswereBasic> SendSmsAsync(viSms sms);
        ValueTask<AnswereBasic> ConfirmSmsAsync(viSms sms);
    }
}
