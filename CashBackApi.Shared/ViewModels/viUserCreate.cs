using AsbtCore.UtilsV2;
using System.ComponentModel.DataAnnotations;

namespace CashBackApi.Shared.ViewModels
{
    public sealed class viUserCreate
    {
        [Required]
        public string Phone { get; set; }
        public string FullName { get; set; }

        public AnswerBasic Validate()
        {
            if (Phone.IsNotEmpty()) return new AnswerBasic(600, "Номер телефона пустой");

            return new AnswerBasic(0, "");
        }
    }
}
