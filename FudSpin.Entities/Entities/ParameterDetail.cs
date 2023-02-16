using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class ParameterDetail : BaseEntity
    {
        public string Value { get; set; }

        public string? Value2 { get; set; }

        public string? Value3 { get; set; }

        public string? Value4 { get; set; }
        public string? Description { get; set; }

        [ForeignKey("ParameterMaster_ParameterDetail")]
        public Guid ParameterMasterID { get; set; }
        public virtual ParameterMaster ParameterMaster_ParameterDetail { get; set; }
     

        [InverseProperty("ParameterDetail_Nationality")]
        public virtual List<User> ParameterDetail_Nationality { get; set; }
    }
}
