using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class ParameterMaster : BaseEntity
    {
        public string ParameterName { get; set; }

        public bool IsEditable { get; set; } = true;
        [InverseProperty("ParameterMaster_ParameterDetail")]
        public virtual List<ParameterDetail> ParameterMaster_ParameterDetail { get; set; }
    }
}
