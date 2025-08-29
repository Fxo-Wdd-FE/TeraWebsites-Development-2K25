using System.Diagnostics;
using AWT_CRM_Repo.ViewModels;
using AWT_Theme.Repository;
using IlmAcademy.Models;
using IlmAcademy.Repository;
using IlmAcademy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IlmAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;
        private readonly ContentRepository _contentRepository;
        private readonly WebsiteSettingRepository websiteSettingRepository;
        private readonly CRMIntegrationRepo integrationRepo;
        private readonly CourseRepo _course;
        PagesViewModel vm = new PagesViewModel();
        EmailVM emailVM = new EmailVM();
        public HomeController(ILogger<HomeController> logger, IConfiguration config, ContentRepository content, WebsiteSettingRepository websiteSettingRepository)
        {
            _logger = logger;
            _config = config;
            PagesViewModel.Theme = _config.GetValue<string>("WebsiteSettings:Theme");
            _contentRepository = new ContentRepository(_config);
            integrationRepo = new CRMIntegrationRepo();
            _course = new CourseRepo(_config);
            websiteSettingRepository = new WebsiteSettingRepository(_config);
            vm.websiteId = _config.GetValue<int>("WebsiteSettings:WebsiteId");
            PagesViewModel.CMSApiUrl = _config.GetValue<string>("WebsiteSettings:CMSAPIUrl");
            PagesViewModel.Theme = _config.GetValue<string>("WebsiteSettings:Theme");
            PagesViewModel.ContentUrl = _config.GetValue<string>("WebsiteSettings:ContentUrl");
            PagesViewModel.AnalyticCode = _config.GetValue<string>("WebsiteSettings:AnalyticsCode");
            PagesViewModel.WebsiteUrl = _config.GetValue<string>("WebsiteSettings:WebsiteUrl");
            PagesViewModel.SuccessMsg = _config.GetValue<string>("EmailContent:SuccessMsg");
            PagesViewModel.ErrorMsg = _config.GetValue<string>("EmailContent:ErrorMsg");
            PagesViewModel.MarketApiUrl = _config.GetValue<string>("WebsiteSettings:StoreAPIUrl");
            PagesViewModel.IntegrationId = _config.GetValue<int>("WebsiteSettings:IntegrationId");
            PagesViewModel.CRMUrl = _config.GetValue<string>("WebsiteSettings:CRMUrl");
            PagesViewModel.CompanyCode = _config.GetValue<string>("WebsiteSettings:CompanyCode");
            PagesViewModel.AcademyApi = _config.GetValue<string>("WebsiteSettings:AcademyApi");
            var websiteId = _config.GetValue<string>("AppData:WebsiteId");
            var apiUrl = _config.GetValue<string>("AppData:ApiUrl");
            PagesViewModel.CRMUrl = _config.GetValue<string>("WebsiteSettings:CRMUrl");
            if (PagesViewModel.websiteSettingsValue == null || PagesViewModel.websiteSettingsValue?.WebsiteSettingId == null || PagesViewModel.websiteSettingsOtherValue == null)
            {
                var res = websiteSettingRepository.GetWebsiteSettings(vm);
                var ores = websiteSettingRepository.GetWebsiteOtherSettings(vm);
                if (res.statusCode.Equals("200"))
                {
                    PagesViewModel.websiteSettingsValue = res.websiteSetting;
                    PagesViewModel.websiteSettingsOtherValue = ores.websiteOtherSettings;
                }
            }

        }
        public IActionResult Index()
        {
            var i = _contentRepository.GetWebsiteContentByContentSlug(vm, "home-page-3107");
            var ii = _contentRepository.GetWebsiteContentByContentTypeAndSlug(vm, "Features", "features");
            var res = _contentRepository.GetWebsiteContentByContentSlug(vm, "why-choose-ilm-academy-2219");
            
            vm.MiscData = res.contentItem;
            vm.ContentTypeSlug = i.contentItem;
            vm.ContentTypeSlugs = ii.contentItems;
            return View(vm);
        }

        [Route("about-us")]
        public IActionResult About()
        {
            var i = _contentRepository.GetWebsiteContentByContentSlug(vm, "about-us-2338");
            var res = _contentRepository.GetWebsiteContentByContentSlug(vm, "why-choose-ilm-academy-2219");
            vm.ContentTypeSlug = i.contentItem;
            vm.MiscData = res.contentItem;
            return View(vm);
        }
        [HttpGet]
        [Route("ilm-bangloro")]
        public IActionResult IlmBangloro()
        {
            var ilm = _contentRepository.GetWebsiteContentByContentSlug(vm, "ilm-academy-bengaluru-2962");
            vm.ContentTypeSlug = ilm.contentItem;
            return PartialView("~/Views/Home/_PartialIlmBangloro.cshtml",vm);
        }
        [HttpGet]
        [Route("skills")]
        public IActionResult skill()
        {
            var ilm = _contentRepository.GetWebsiteContentByContentSlug(vm, "career-learning-advantage-9845");
            vm.ContentTypeSlug = ilm.contentItem;
            return PartialView("~/Views/Home/_PartialLerningSkill.cshtml", vm);
        }
        [HttpGet]
        [Route("testimonials")]
        public IActionResult Testimonial()
        {
            var ilm = _contentRepository.GetWebsiteContentByContentSlug(vm, "student-success-testimonials-2602");
            vm.ContentTypeSlug = ilm.contentItem;
            return PartialView("~/Views/Home/_PartialTestimonial.cshtml", vm);
        }

        [Route("gallery")]
        public IActionResult Gallery()
        {
            var ilm = _contentRepository.GetWebsiteContentByContentSlug(vm, "gallery-2492");
            vm.ContentTypeSlug = ilm.contentItem;
            return View(vm);
        }
        [Route("international-students")]
        public IActionResult InternatinalStudents()
        {
            var ilm = _contentRepository.GetWebsiteContentByContentSlug(vm, "international-students-9686");
            var i = _contentRepository.GetWebsiteContentByContentSlug(vm, "on-campus-programs-7913");
            var con = _contentRepository.GetWebsiteContentByContentSlug(vm, "online-programs-1565");
            vm.ContentTypeSlug = ilm.contentItem;
            vm.ContentData = i.contentItem;
            vm.MiscData = con.contentItem;
            return View(vm);
        }
        [Route("Form-index")]
        public IActionResult Form()
        {
            var res = integrationRepo.GetIntegrationSettings(PagesViewModel.CRMUrl, PagesViewModel.CompanyCode, "key", PagesViewModel.IntegrationId);
            vm.Products = res.Products;
            vm.OpportunityTypes = res.OpportunityTypes;
            vm.Countries = res.Countries;

            return PartialView("/Views/Home/_PartialForm.cshtml", vm);
        }
        [Route("submitform")]
        public IActionResult SubmitForm(LeadRequestVM model)
        {
            model.Key = "abc";
            model.IntegrationId = PagesViewModel.IntegrationId;
            var res = integrationRepo.AddLead(PagesViewModel.CRMUrl, PagesViewModel.CompanyCode, model);
            if (res.Status == "200")
            {
                return Json(new { response = "success", title = "Success", message = "Lead Sent Successfully", Type = "success" });
            }
            else
            {
                return Json(new { response = "failed", title = "Error", message = "Error Occurred ", Type = "error" });
            }
        }
        [Route("contact-us")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("courses")]
        public IActionResult Courses()
        {
            vm.Courses = _course.GetAllCourses().Courses;
            return View(vm);
        }
        [Route("course-details/{activityCoursesId}")]
        public IActionResult CourseDetail(int activityCoursesId)
        {
            vm.Course = _course.GetCourseById(activityCoursesId).Course;
            return View(vm);
        }
        //[Route("apply-online/{activityCoursesId}")]
        //public IActionResult ApplyOnline(int activityCoursesId)
        //{
        //    vm.StudentCategories = _course.GetAllStudentCategories().Categories;
        //    vm.Course = _course.GetCourseById(activityCoursesId).Course;
        //    return View(vm);
        //}
        [Route("apply-online/{activityCoursesId}")]
        public IActionResult ApplyOnline(int activityCoursesId)
        {
            var vm = new PagesViewModel();
            vm.Course = _course.GetCourseById(activityCoursesId).Course;
            vm.StudentCategories = _course.GetAllStudentCategories().Categories;
            vm.StudentApplications.Add(new StudentProfileVm());

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Confirmation(PagesViewModel model)
        {
   
            return View("_PartialFormConfirmation", model);
        }
        [Route("study-abroad")]
        public IActionResult IndianStudents()
        {
            var res = _contentRepository.GetWebsiteContentByContentSlug(vm, "study-abroad-9322");
            var des = _contentRepository.GetWebsiteContentByContentSlug(vm, "programs-destinations-5859");
            vm.ContentTypeSlug = res.contentItem;
            vm.MiscData = des.contentItem;

            return View(vm);
        }


        [HttpPost]
        [Route("insert-profile-data")]
        public async Task<IActionResult> InsertProfileData([FromForm] StudentProfileVm model)
        {
            if (model == null)
                return BadRequest("Student data is null");

            //if (model.Photo != null && model.Photo.Length > 0)
            //{
            //    using var ms = new MemoryStream();
            //    await model.Photo.CopyToAsync(ms);
            //    model.PhotoBytes = ms.ToArray();
            //}
            //else if (!string.IsNullOrEmpty(model.PhotoBase64))
            //{
            //    model.PhotoBytes = Convert.FromBase64String(model.PhotoBase64);
            //}

            var inserted = _course.InsertStudentProfile(model);
            return Ok(inserted);
        }
        //[HttpPost]
        //[Route("insert-profile-data")]
        //public async Task<IActionResult> InsertProfileData([FromForm] StudentProfileVm model)
        //{
        //    if (model == null)
        //        return BadRequest(new { success = false, message = "Student data is null" });

        //    try
        //    {
        //        if (model.Photo != null && model.Photo.Length > 0)
        //        {
        //            using var ms = new MemoryStream();
        //            await model.Photo.CopyToAsync(ms);
        //            model.PhotoBytes = ms.ToArray();
        //        }
        //        else if (!string.IsNullOrEmpty(model.PhotoBase64))
        //        {
        //            model.PhotoBytes = Convert.FromBase64String(model.PhotoBase64);
        //        }

        //        var response = _course.InsertStudentProfile(model);

        //        if (response == null)
        //            return StatusCode(StatusCodes.Status500InternalServerError,
        //                new { success = false, message = "Insert failed. Null response from DB." });

        //        if (response.StudentProfileId > 0)
        //        {
        //            return Ok(new
        //            {
        //                success = true,
        //                studentId = response.StudentProfileId,
        //                message = response.Message ?? "Student profile inserted successfully."
        //            });
        //        }

        //        return StatusCode(StatusCodes.Status500InternalServerError, new
        //        {
        //            success = false,
        //            message = response.Message ?? "Failed to insert student profile."
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            new { success = false, message = "Error: " + ex.Message });
        //    }
        //}

        [Route("application-submited-success")]
        public IActionResult FeeVoucher()
        {
            return View();

        }



        [Route("courses/english-diploma")]
        public IActionResult CourseDiplomaInEnglish()
        {
            return View();
        }
        [Route("courses/spoken-english")]
        public IActionResult CourseSpokenEnglish()
        {
            return View();
        }
        [Route("courses/ielts")]
        public IActionResult CourseIELTS()
        {
            return View();
        }
        [Route("courses/toefl")]
        public IActionResult CourseITOEFL()
        {
            return View();
        }
        [Route("courses/toeic")]
        public IActionResult CourseITOEIC()
        {
            return View();
        }
        [Route("courses/accent-improvisation")]
        public IActionResult CourseIAccentImprovision()
        {
            return View();
        }

        [Route("blog")]
        public IActionResult Blog()
        {
            var ii = _contentRepository.GetWebsiteContentByContentTypeAndSlug(vm, "Blogs", "blogs");
            vm.ContentTypeSlugs = ii.contentItems;
            return View(vm);
        }
        [Route("blog/{contentslug}")]
        public IActionResult BlogDetail(string contentslug)
        {
            var res = _contentRepository.GetWebsiteContentByContentSlug(vm, contentslug);
            var ii = _contentRepository.GetWebsiteContentByContentTypeAndSlug(vm, "Blogs", "blogs");
            vm.ContentTypeSlugs = ii.contentItems;
            vm.ContentTypeSlug = res.contentItem;
            return View("BlogDetail", vm);
        }
        [Route("blog/english-diploma-benefits")]
        public IActionResult BlogEnglishDiplomaBenefits()
        {
            return View();
        }
        [Route("blog/spoken-english-tips")]
        public IActionResult BlogSpokenEnglish()
        {
            return View();
        }
        [Route("blog/ielts-success-guide")]
        public IActionResult BlogScoreInIELTS()
        {
            return View();
        }
        [Route("blog/toefl-preparation")]
        public IActionResult BlogTOEFLPrep()
        {
            return View();
        }  
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
