using CashBackApi.Shared.ViewModels;
using System.Threading.Tasks;

namespace CashBackApi.Shared.Interfaces
{
    public interface IUserService
    {
        ValueTask<Answer<viUser>> AuthenticateAsync(viAuthenticateModel model, string ip);
        ValueTask<AnswerBasic> CreateUserAsync(viUserCreate create);
    }
}
