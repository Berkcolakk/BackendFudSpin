namespace RentalHouseManagement.Entities.Base
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public virtual Guid CompanyID { get; set; }
        public bool IsActive { get; set; }
        public string? CrtIPAddress { get; set; }
        public Guid CrtUserID { get; set; }
        public DateTime CrtDate { get; set; }
        public string? UpdIPAddress { get; set; }
        public DateTime UpdDate { get; set; }
        public Guid UpdUserID { get; set; }
    }
}
