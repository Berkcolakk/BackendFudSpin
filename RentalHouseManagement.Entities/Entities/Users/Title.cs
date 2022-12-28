using RentalHouseManagement.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentalHouseManagement.Entities.Entities.Users
{
    public class Title : BaseEntity
    {
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Description { get; set; }
        [InverseProperty("PKUsersTitles")]
        public ICollection<User>? PKUsersTitles { get; set; }
    }
}
