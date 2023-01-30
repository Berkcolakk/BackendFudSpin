using FudSpin.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Entities.Entities
{
    public class Language : BaseEntity
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Lang { get; set; }
    }
}
