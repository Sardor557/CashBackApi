using AsbtCore.UtilsV2;
using System.ComponentModel.DataAnnotations;

namespace CashBackApi.Shared.ViewModels
{
    public sealed class viAuthenticateModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Пользователь{Login} пароль:{Password}";
        }

        public AnswereBasic Validate()
        {
            if (Login.IsNullorEmpty() || Password.IsNullorEmpty())
                return new AnswereBasic(600, "Логин или пароль пустые");

            return new AnswereBasic(0, "");
        }
    }
}
