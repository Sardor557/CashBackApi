using CashBackApi.Shared.ViewModels;
using System.Threading.Tasks;

namespace CashBackApi.Shared.Interfaces
{
    public interface ICashBackService
    {
        ValueTask<AnswerBasic> ChangeCashbackAsync(viCashback cashback);
        Task CreateCashbackAsync(int userId);
    }
}
