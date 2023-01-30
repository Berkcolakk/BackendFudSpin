using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class SpinnerMaster : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("IPSpinnerMaster")]
        public Guid UserID { get; set; }
        public virtual User IPSpinnerMaster { get; set; }
        [InverseProperty("IPSpinnerDetail")]
        public virtual ICollection<SpinnerDetail> IPSpinnerDetail { get; set; }
    }
}
