using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Users
{
    public class CreateUserDTO
    {
        public string? Description { get; set; }
        public required string? Identity { get; set; }
        public required Guid NationalityID { get; set; }
        public required Guid GenderID { get; set; }
        public required string? UserName { get; set; }
        public required string? NameSurname { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string? Password { get; set; }
        public required string? SecondPassword { get; set;}
    }
}
