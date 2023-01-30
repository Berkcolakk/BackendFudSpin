using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class SpinnerDetailSelection : BaseEntity
    {
        [ForeignKey("IPSpinnerDetailSelection")]
        public Guid SpinnerDetailID { get; set; }
        public virtual SpinnerDetail IPSpinnerDetailSelection { get; set; }
    }
}
