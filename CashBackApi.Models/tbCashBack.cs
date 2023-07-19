using System.ComponentModel.DataAnnotations;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace CashBackApi.Models
{
    public class tbCashBack : BaseModel
    {
        [IndexColumn, Required]
        public int UserId { get; set; }
        public virtual tbUser User { get; set; }

        [Required]
        public long CashBack { get; set; }
    }
}
