namespace FudSpin.Entities.Base
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public bool IsActive { get; set; } = true;
        public string? CrtIPAddress { get; set; }
        public Guid CrtUserID { get; set; }
        public DateTime CrtDate { get; set; } = DateTime.UtcNow;
        public string? UpdIPAddress { get; set; } 
        public DateTime UpdDate { get; set; } = DateTime.UtcNow;
        public Guid UpdUserID { get; set; }
    }
}
