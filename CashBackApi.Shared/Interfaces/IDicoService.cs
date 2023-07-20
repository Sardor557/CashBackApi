using CashBackApi.Models;
using CashBackApi.Shared.ViewModels;
using System.Threading.Tasks;

namespace CashBackApi.Shared.Interfaces
{
    public interface IDicoService
    {
        ValueTask<Answer<spUserType[]>> GetUserTypesAsync();
        ValueTask<Answer<spStatus[]>> GetStatusesAsync();
    }
}
