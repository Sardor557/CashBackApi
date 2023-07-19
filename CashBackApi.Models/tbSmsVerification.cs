using System.ComponentModel.DataAnnotations;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace CashBackApi.Models
{
    public class tbSmsVerification : BaseModel
    {
        public int Code { get; set; }
        public string Phone { get; set; }

        [IndexColumn, Required]
        public int UserId { get; set; }
        public virtual tbUser User { get; set; }

        public bool IsVerificated { get; set; }
    }
}
