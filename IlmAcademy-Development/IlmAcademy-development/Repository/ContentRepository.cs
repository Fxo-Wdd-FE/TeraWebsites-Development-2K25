using Anyweb.Classes;
using Newtonsoft.Json;
using IlmAcademy.ViewModels;

namespace IlmAcademy.Repository
{
    public class ContentRepository
    {
        private readonly ApiMethods _apiMethods;
        private readonly IConfiguration configuration;
        private string ConnectionString = "";
        public ContentRepository(IConfiguration configuration)
        {
            _apiMethods = new ApiMethods();
            this.configuration = configuration;
            ConnectionString = configuration.GetValue<string>("WebsiteSettings:CompanyName");
        }
        
        public WebsiteContentResponseVM GetWebsiteContentByContentSlug(PagesViewModel vm, string ContentSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/{ContentSlug}";
            var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = vm.websiteId, Slug = $@"{ContentSlug}" });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }
        public ThemeResponseVM GetMainMenu(string? Title)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/GetMenuByMainMenu";
            var myContent = JsonConvert.SerializeObject(new ThemeSettingsRequest() { WebsiteId = 1, Title = Title });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new ThemeResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<ThemeResponseVM>(apiResponse.ResponseString);
            return returnData;

        }
        public WebsiteContentResponseVM GetOtherWebsiteContentByContentSlug(int WebsiteId, string ContentSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/v2/{ContentSlug}";
            var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = WebsiteId, Slug = $@"{ContentSlug}" });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;

        }

        public WebsiteContentResponseVM GetWebsiteContentByContentTypeAndSlug(PagesViewModel vm, string ContentType, string TypeSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/{ContentType}/{TypeSlug}";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, TypeSlug = TypeSlug });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }
        public WebsiteContentResponseVM GetWebsiteContentByContentTypeAndSlugv2(PagesViewModel vm, string ContentType, string TypeSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/v2/{ContentType}/{TypeSlug}";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, TypeSlug = TypeSlug });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }
        public WebsiteContentResponseVM GetWebsiteCategoriesByContentType(PagesViewModel vm, string TypeSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/CategoryByType";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, TypeSlug = TypeSlug });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }

        public WebsiteContentResponseVM GetWebsiteCategoriesByWebsiteContentType(PagesViewModel vm, string TypeSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/CategoryByWebsiteAndType";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, TypeSlug = TypeSlug });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }

        public WebsiteContentResponseVM GetWebsiteContentByContentTypeAndCategory(PagesViewModel vm, string ContentType, string CategorySlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/{ContentType}/{CategorySlug}";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, CategorySlug = CategorySlug, TypeSlug = ContentType, isCategoryContent = true });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;

        }
        public WebsiteContentResponseVM GetWebsiteContentByContentTypeAndCategoryv2(PagesViewModel vm, string ContentType, string CategorySlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/v2/{ContentType}/{CategorySlug}";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = vm.websiteId, CategorySlug = CategorySlug, TypeSlug = ContentType, isCategoryContent = true });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;

        }
        public WebsiteContentResponseVM GetContentData(PagesViewModel vm, string ContentSlug)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/Website/Content/GetContentElements";
            var myContent = JsonConvert.SerializeObject(new WebsiteRequestVM() { WebsiteId = vm.websiteId, Slugs = new List<string>() { $@"contentquicklinks", ContentSlug } });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;

        }

        public WebsiteContentResponseVM EmailSend(PagesViewModel vm, EmailVM e)
        {

            var apiResponse = new ApiResponse();
            e.WebsiteId = vm.websiteId;
            var url = $@"api/Website/SubmitContactForm";
            var myContent = JsonConvert.SerializeObject(e);
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }

        public WebsiteContentResponseVM Subscriber(PagesViewModel vm, EmailVM e)
        {

            var apiResponse = new ApiResponse();
            e.WebsiteId = vm.websiteId;
            var url = $@"api/Website/SubscribeNow";
            var myContent = JsonConvert.SerializeObject(e);
            apiResponse = _apiMethods.PostMethod(PagesViewModel.CMSApiUrl, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new WebsiteContentResponseVM()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<WebsiteContentResponseVM>(apiResponse.ResponseString);
            return returnData;
        }


       


    }

}
