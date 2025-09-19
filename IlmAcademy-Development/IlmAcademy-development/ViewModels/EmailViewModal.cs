namespace EmailServices.ViewModal
{
    public class MainVm
    {
        public string? WebsiteName { get; set; }
        public int WebsiteId { get; set; }
        public string? EmailTo { get; set; }
    }
    public class EmailViewModal
    {

        public int websiteId { get; set; }
        public int QueryId { get; set; }
        public string QueryLevel { get; set; }
        public string TaskType { get; set; }
        public int Pages { get; set; }
        public string SpacingType { get; set; }
        public string MobileNumber { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }


        public string? EmailBody { get; set; }

        public string? EmailType { get; set; }




        public string? Name { get; set; }
        public string? Email { get; set; }
        public int WebsiteId { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? NOP { get; set; }
        public string? Mobile { get; set; }
        public string? AcademicLevel { get; set; }
        public string? Poster { get; set; }
        public string? Task { get; set; }
        public string? StartDate { get; set; }
        public byte[]? CV { get; set; }
        public string? Space { get; set; }
        public string? Cnic { get; set; }
        public byte[]? Document { get; set; }
        public string? FileName { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
    public class EmailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string HtmlMessage { get; set; }
    }
}
