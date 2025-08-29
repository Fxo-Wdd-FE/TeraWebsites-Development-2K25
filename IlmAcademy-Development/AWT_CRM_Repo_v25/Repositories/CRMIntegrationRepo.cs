using Anyweb.Classes;
using Microsoft.Extensions.Configuration;
using AWT_CRM_Repo.ViewModels;
using Newtonsoft.Json;

namespace AWT_Theme.Repository
{
	public class CRMIntegrationRepo
	{
		private readonly ApiMethods _apiMethods;
		private readonly IConfiguration configuration;
		
		public CRMIntegrationRepo()
		{
			_apiMethods = new ApiMethods();
		}
		public IntegrationResponseModel GetIntegrationSettings(string baseurl,string? cs ,string? key,int? IntegrationId )
		{
			var apiResponse = new ApiResponse();
			var url = $@"api/CRM/Integration/GetIntegrationSettings";
			var myContent = JsonConvert.SerializeObject(new RequestVM() { Key = "abc", IntegrationId = IntegrationId });
			apiResponse = _apiMethods.PostMethod(baseurl, url, myContent, cs);
			if (string.IsNullOrEmpty(apiResponse.ResponseString))
			{
				var rd = new IntegrationResponseModel()
				{
					Status = apiResponse.Status,
					statusCode = apiResponse.StatusCode,
					Message = apiResponse.Message,
				};
				return rd;
			}
			var returnData = JsonConvert.DeserializeObject<IntegrationResponseModel>(apiResponse.ResponseString);
			return returnData;

		}
		public ResponseModel AddLead(string baseurl, string? cs, LeadRequestVM model)
		{
			var apiResponse = new ApiResponse();
			var url = $@"api/CRM/Leads/AddLeads";
			var myContent = JsonConvert.SerializeObject(model);
			apiResponse = _apiMethods.PostMethod(baseurl, url, myContent, cs);
			if (string.IsNullOrEmpty(apiResponse.ResponseString))
			{
				var rd = new ResponseModel()
				{
					Status = apiResponse.Status,
					statusCode = apiResponse.StatusCode,
					Message = apiResponse.Message,
				};
				return rd;
			}
			var returnData = JsonConvert.DeserializeObject<ResponseModel>(apiResponse.ResponseString);
			return returnData;

		}
	}
}
