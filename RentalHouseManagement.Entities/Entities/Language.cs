using RentalHouseManagement.Entities.Base;
using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Entities.Entities
{
    public class Language : BaseEntity
    {
        public string? Key { get; set; }
        public string? TR { get; set; }
        public string? EN { get; set; }
    }
}
