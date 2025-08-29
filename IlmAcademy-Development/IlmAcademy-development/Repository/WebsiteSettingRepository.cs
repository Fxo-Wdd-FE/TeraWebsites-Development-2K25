using Anyweb.Classes;
using Newtonsoft.Json;
using IlmAcademy.ViewModels;

namespace IlmAcademy.Repository
{
    public class WebsiteSettingRepository
    {

        private readonly ApiMethods _apiMethods;
        private readonly IConfiguration configuration;
        private string ConnectionString = "";
        private string CMSAPIURL = "";

        private int WebsiteId = 0;

        public WebsiteSettingRepository(IConfiguration configuration)
        {
            _apiMethods = new ApiMethods();
            this.configuration = configuration;
            ConnectionString = configuration.GetValue<string>("WebsiteSettings:CompanyName");
            WebsiteId = configuration.GetValue<int>("WebsiteSettings:WebsiteId");
            CMSAPIURL = configuration.GetValue<string>("WebsiteSettings:CMSAPIUrl");


        }
        

        public WebsiteSettingResponseVM GetWebsiteSettings(PagesViewModel vm)
        {
            var apiResponse = new ApiResponse();
            var url = "api/Website/Settings/GetWebsiteSettings";
            var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = vm.websiteId });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteSettingResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteSettingResponseVM>(apiResponse.ResponseString);
            return returnData;

        }

        public WebsiteSettingResponseVM GetWebsiteOtherSettings(PagesViewModel vm)
        {
            var apiResponse = new ApiResponse();
            var url = "api/Website/setting/GetOtherSettings";
            var myContent = JsonConvert.SerializeObject(new WebsiteRequestOVM()
            {
                WebsiteId = vm.websiteId,
                settingsName = new List<string> {
                "Facebook","Twitter", "qatar-number", "contact-uk", "pak-contact","Email","Address","Mobile","Landline","Google Analytics" }
            });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteSettingResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteSettingResponseVM>(apiResponse.ResponseString);
            return returnData;

        }

        public WebsiteSettingResponseVM AddVisitorlOG(VisitorLogRequestVM vm)
        {
            vm.websiteId = WebsiteId;
            var apiResponse = new ApiResponse();
            var url = "api/Website/AddVisitorLog";
            var myContent = JsonConvert.SerializeObject(vm);
            apiResponse = _apiMethods.PostMethod(CMSAPIURL, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteSettingResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteSettingResponseVM>(apiResponse.ResponseString);
            return returnData;

        }


        //public WebsiteSettingResponseVM GetWebsiteSettingsByKey(PagesViewModel vm)
        //{
        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Settings/GetWebsiteSettings";
        //    var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = vm.websiteId });
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteSettingResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteSettingResponseVM>(apiResponse.ResponseString);
        //    return returnData;

        //}




        //public WebsiteContentResponseVM GetWebsiteMenu(PagesViewModel vm, string Slug)
        //{
        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Seting/GetMenu";
        //    var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = vm.websiteId, Slug = Slug });
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteContentResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
        //    return returnData;

        //}


        //public WebsiteContentResponseVM GetFooter(PagesViewModel vm)
        //{

        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Content/GetContentElements";
        //    var model = new WebsiteRequestVM()
        //    {
        //        WebsiteId = vm.websiteId,
        //        Slugs = new List<string>()
        //        {
        //            "home-contact",
        //            "home-quick-links",
        //            "home-about-us-menu",
        //            "home-newsletter"
        //        }
        //    };

        //    var myContent = JsonConvert.SerializeObject(model);
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteContentResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
        //    return returnData;
        //}


        //public WebsiteContentResponseVM GetHomeMainSlider(PagesViewModel vm)
        //{

        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Content/GetContentElements";
        //    var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM()
        //    {
        //        WebsiteId = vm.websiteId,
        //        Slugs = new List<string>() { "slider-one-54244", "slider-two-14272" }
        //    });
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteContentResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
        //    return returnData;

        //}

        //public WebsiteContentResponseVM GetPictures(PagesViewModel vm)
        //{

        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Content/GetContentElements";
        //    var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM()
        //    {
        //        WebsiteId = vm.websiteId,
        //        //Slug="picture-3005"
        //        Slugs = new List<string>() { "slider-6588"/*, "slider-two-14272" */}
        //    });
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteContentResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
        //    return returnData;

        //}


        //public WebsiteContentResponseVM GetTestimonials(PagesViewModel vm, string ContentSlug)
        //{

        //    var apiResponse = new ApiResponse();
        //    var url = "api/Website/Content/GetContentElements";
        //    var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM()
        //    {
        //        WebsiteId = vm.websiteId,
        //        Slugs = new List<string>() { ContentSlug/*, "aya-testimonial-two-2499" */}
        //    });
        //    apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
        //    if (string.IsNullOrEmpty(apiResponse.ResponseString))
        //    {
        //        var rd = new WebsiteContentResponseVM()
        //        {
        //            Status = apiResponse.Status,
        //            statusCode = apiResponse.StatusCode,
        //            Message = apiResponse.Message,
        //        };
        //        return rd;
        //    }
        //    var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
        //    return returnData;

        //}

        //public void ClearWebsiteSettings()
        //{
        //    PagesViewModel.websiteSettingsValue = new WebsiteSettingVm();
        //}



    }

}
