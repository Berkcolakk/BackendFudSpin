using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalHouseManagement.Entities.Base;

namespace RentalHouseManagement.Entities.Entities.Companies
{
    public class Company : BaseEntity
    {
        public override Guid CompanyID { get => ID; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? Address { get; set; }
        public string? Identity { get; set; }
    }
}
