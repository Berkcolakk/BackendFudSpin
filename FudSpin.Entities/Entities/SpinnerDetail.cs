using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class SpinnerDetail : BaseEntity
    {
        public string? Color { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("IPSpinnerDetail")]
        public Guid SpinnerMasterID { get; set; }
        public virtual SpinnerMaster IPSpinnerDetail { get; set; }
        [InverseProperty("IPSpinnerDetailSelection")]
        public virtual ICollection<SpinnerDetailSelection> SpinnerDetailSelection { get; set; }
    }
}
