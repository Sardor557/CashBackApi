using System.ComponentModel.DataAnnotations;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace CashBackApi.Models
{
    public class tbUser : BaseModel
    {
        public string FullName { get; set; }

        [Required, IndexColumn(IsUnique = true)]
        public string Phone { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        [IndexColumn]
        public int UserTypeId { get; set; }
        public virtual spUserType UserType { get; set; }        
    }
}
