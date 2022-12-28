using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Dto.Users
{
    public class AuthenticationResponse
    {
        public Guid UserID { get; set; }
        public string? Description { get; set; }
        public string? Identity { get; set; }
        public string? Language { get; set; }
        public Guid PlaceOfBirth { get; set; }
        public Guid Nationality { get; set; }
        public string? UserName { get; set; }
        public string? NameSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } } 
        public Guid TitleID { get; set; }
        //public string Token { get; set; }
    }
}
