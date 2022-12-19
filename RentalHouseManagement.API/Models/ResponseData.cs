namespace RentalHouseManagement.Api.Models
{
    public class ResponseData
    {
        public string? ErrorMessage { get; set; }
        public int? PageNumber { get; set; } = 0;
        public bool Error { get { return !string.IsNullOrWhiteSpace(ErrorMessage) ? true : false; } }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
