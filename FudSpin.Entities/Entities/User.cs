using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class User : BaseEntity
    {
        public string? Description { get; set; }
        public string? Identity { get; set; }
        public string? Language { get; set; } = "EN";
        public Guid PlaceOfBirth { get; set; }
        public Guid Nationality { get; set; }
        public string? UserName { get; set; }
        public string? NameSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        public string? Password { get; set; }
        public string? SecondPassword { get; }
        [InverseProperty("IPSpinnerMaster")]
        public virtual ICollection<SpinnerMaster> SpinnerMaster { get; set;}
    }
}
