using Anyweb.Classes;
using IlmAcademy.ViewModels;
using Newtonsoft.Json;

namespace IlmAcademy.Repository
{
    public class CourseRepo
    {


        private readonly ApiMethods _apiMethods;
        private readonly IConfiguration configuration;
        private string ConnectionString = "";
        public CourseRepo(IConfiguration configuration)
        {
            _apiMethods = new ApiMethods();
            this.configuration = configuration;
            ConnectionString = configuration.GetValue<string>("WebsiteSettings:CompanyName");
        }
        public ResponseCoursesVm GetAllCourses()
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/AcademicPortal/GetAllCourses";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = 1 });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.AcademyApi, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new ResponseCoursesVm()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<ResponseCoursesVm>(apiResponse.ResponseString);
            return returnData;
        }
        public ResponseCoursesVm GetCourseById(int activityCourseId)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/AcademicPortal/GetCourseById/{activityCourseId}";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = 1 });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.AcademyApi, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new ResponseCoursesVm()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<ResponseCoursesVm>(apiResponse.ResponseString);
            return returnData;
        }
        public ResponseCoursesVm GetAllStudentCategories()
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/AcademicPortal/GetAllStudentCategory";
            var myContent = JsonConvert.SerializeObject(new BlogRequestVM() { WebsiteId = 1 });
            apiResponse = _apiMethods.PostMethod(PagesViewModel.AcademyApi, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new ResponseCoursesVm()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<ResponseCoursesVm>(apiResponse.ResponseString);
            return returnData;
        }
        public ResponseCoursesVm InsertStudentProfile(StudentProfileVm model)
        {
            var apiResponse = new ApiResponse();
            var url = $@"api/AcademicPortal/InsertStudentProfile";
            var myContent = JsonConvert.SerializeObject(model);
            apiResponse = _apiMethods.PostMethod(PagesViewModel.AcademyApi, url, myContent, ConnectionString);
            if (string.IsNullOrEmpty(apiResponse.ResponseString))
            {
                var rd = new ResponseCoursesVm()
                {
                    Status = apiResponse.Status,
                    statusCode = apiResponse.StatusCode,
                    Message = apiResponse.Message,
                };
                return rd;
            }
            var returnData = JsonConvert.DeserializeObject<ResponseCoursesVm>(apiResponse.ResponseString);
            return returnData;
        }
    }
}
