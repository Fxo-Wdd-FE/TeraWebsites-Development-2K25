namespace AWT_CRM_Repo.ViewModels
{
    public class CRMReqestModels
    {
    }
    public class RequestVM
    {
        public string? Key { get; set; }
        public int? IntegrationId { get; set; }
    }
    public class LeadRequestVM
    {
		public string? Key { get; set; }
		public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public int? CountryCodeId { get; set; }
        public int? ProductId { get; set; }
        public int? OpportunityTypeId { get; set; }
        public int? IntegrationId { get; set; }
        public string? Message { get; set; }
    }
}
