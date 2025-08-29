namespace AWT_CRM_Repo.ViewModels
{
    public class CRMResponseModels
    {
    }
    public class Products
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
    }
    public class Countries
    {
        public int? CountryId { get; set; }
        public string? CallingCode { get; set; }
    }
    public class OpportunityTypes
    {
        public int? OpportunityTypeId { get; set; }

        public string? Title { get; set; }
        
    }
	public class ResponseModel
	{
		public string? Status { get; set; }
		public string? statusCode { get; set; }
		public string? Message { get; set; }
		
	}
	public class IntegrationResponseModel
	{
		public string? Status { get; set; }
		public string? statusCode { get; set; }
		public string? Message { get; set; }
		public List<Products> Products { get; set; }
        public List<OpportunityTypes> OpportunityTypes { get; set; }
        public List<Countries> Countries { get; set; }


	}
}
