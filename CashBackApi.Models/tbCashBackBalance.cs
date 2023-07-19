using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace CashBackApi.Models
{
    public class tbCashBackBalance : BaseModel
    {
        public long Income { get; set; }
        public long Outcome { get; set; }

        [IndexColumn]
        public int CashBackId { get; set; }
        public virtual tbCashBack CashBack { get; set; }
    }
}
