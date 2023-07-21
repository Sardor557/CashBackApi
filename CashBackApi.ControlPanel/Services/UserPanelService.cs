using AsbtCore.UtilsV2;
using CashBackApi.Shared.Interfaces;
using CashBackApi.Shared.ViewModels;
using System.Configuration;
using System.Threading.Tasks;

namespace CashBackApi.ControlPanel.Services
{
    public class UserPanelService : IUserService
    {
        private readonly string ServerUrl;
        private readonly CRestClient client;

        public UserPanelService()
        {
            ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];

            this.client = new CRestClient();
        }
        public async ValueTask<Answer<viUser>> AuthenticateAsync(viAuthenticateModel model, string ip)
        {
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
                return null;

            var r = await client.PostApiStringResultAsync(ServerUrl + "User/login", model);
            if (r.IsSuccess)
                return r.DataStr.FromJson<Answer<viUser>>();
            else
                return new Answer<viUser>(600, "Что-то пошло не так");
        }

        public async ValueTask<AnswerBasic> CreateUserAsync(viUserCreate create) => await client.PostApiAsync<viUserCreate, AnswerBasic>(ServerUrl + "User/login", create);

    }
}
