using AsbtCore.UtilsV2;
using System.ComponentModel.DataAnnotations;

namespace CashBackApi.Shared.ViewModels
{
    public sealed class viUserCreate
    {
        [Required]
        public string Phone { get; set; }
        public string FullName { get; set; }

        public AnswereBasic Validate()
        {
            if (Phone.IsNotEmpty()) return new AnswereBasic(600, "Номер телефона пустой");

            return new AnswereBasic(0, "");
        }
    }
}
