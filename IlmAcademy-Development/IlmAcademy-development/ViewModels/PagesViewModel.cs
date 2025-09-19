using Anyweb;
using AWT_CRM_Repo.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IlmAcademy.ViewModels
{
    public class PagesViewModel
    {


        public static string AnalyticCode { get; set; }
        public static string WebsiteUrl { get; set; }
        public  List<ContentMenuLevel> Menu { get; set; }
        public List<Countries> Countries { get; set; }
        public List<Courses> Courses { get; set; }
        public Courses Course { get; set; }
        public List<OpportunityTypes> OpportunityTypes { get; set; }
        public List<StudentCategories> StudentCategories { get; set; }
        public List<StudentProfileVm> StudentApplications { get; set; } = new();
        public StudentProfileVm StudentApplication { get; set; } = new();
        public List<Products> Products { get; set; }
        public string? Key { get; set; }
        public ContentVm emailTemplate { get; set; }
        public static string CMSApiUrl { get; set; }
        public static string AcademyApi { get; set; }
        public static int? IntegrationId { get; set; }
        public static string? CompanyCode { get; set; }
        public static string ContentUrl { get; set; }
        public static string CRMUrl { get; set; }
        public static string SuccessMsg { get; set; }
        public  static string ErrorMsg { get; set; }
        public static ContentVm? exp8000 { get; set; }
        public static ContentVm? sk { get; set; }
        public static ContentVm? exp7000 { get; set; }
        public static ContentVm? exp6000 { get; set; }
        public static ContentVm? RockClimbing { get; set; }
        public static ContentVm? EasyTrekking { get; set; }
        public static ContentVm? Tours { get; set; }
        public static ContentVm? MultiPleTrip { get; set; }
        public static ContentVm? About { get; set; }
        public static ContentVm? Contact { get; set; }
        public static ContentVm? CTS { get; set; }
        public static ContentVm? Main { get; set; }
        public string Country { get; set; }
        public static string MarketApiUrl { get; set; }
        public static string ThemeColor { get; set; }
        public int websiteId { get; set; }
        public int StoreId { get; set; }
        public string Slug { get; set; }
        public string ProductGroupSlug { get; set; }
        public string ProductSlug { get; set; }

        public static string? Theme { get; set; }
        public static WebsiteSettingVm websiteSettingsValue { get; set; }
        public static List<WebSiteSettingsOtherVM> websiteSettingsOtherValue { get; set; }
        public static ContentVm MainProduct { get; set; }
        public static List<ContentVm> MainApplication { get; set; }
        public static List<ContentVm> Services { get; set; }
        public static List<ContentVm> Programs { get; set; }
        public static List<ContentVm> StaticKnowledgeModules { get; set; }
        public static List<ContentVm> StaticTestimonials { get; set; }
        public static ContentVm StaticClients { get; set; }
        public static ContentVm StaticHome { get; set; }
        public WebsiteSettingVm WebsiteSetting { get; set; }
        public ContentVm? ContentTypeSlug { get; set; }
        public ContentVm? ContentData { get; set; }
     
    
        public string? VisitingCountry { get; set; }
        public string? IpAddress { get; set; }
        public ContentVm? MiscData { get; set; }
        public List<ContentVm>? ContentTypeSlugs { get; set; }
        public List<ContentVm>? Staff { get; set; }
        public string SearchText { get; set; }
        public List<ContentVm>? CategoryList { get; set; }
        public ContentVm? RelatedContent { get; set; }

        public static List<ContentVm>? StaticSliders { get; set; }
        public static ContentVm? StaticSlider { get; set; }
        public static List<ContentVm>? StaticApplications { get; set; }
        public static List<ContentVm>? StaticModules { get; set; }
        public static ContentVm? HomeCounter { get; set; }
        public static List<ContentVm>? StaticBlogs { get; set; }
        public static ContentVm StaticBackground { get; set; }


        #region Commented
        //public static List<ContentVm> StaticPortfolio { get; set; }
        //public string GroupKey { get; set; }
        //public CollectionResponseVM CollectionResponse { get; set; }
        //public ProductResponseVM ProductResponse { get; set; }
        //public List<ContentVm> AllProducts { get; set; }
        //public List<ContentVm> AllSolutions { get; set; }
        //public List<ContentVm> AllApplications { get; set; }
        //public List<ContentVm> AllModules { get; set; }
        //public List<ContentVm> AllFeatures { get; set; }
        //public static List<ContentVm> SolutionsMenu { get; set; }
        //public static List<ContentVm> ApplicationsMenu { get; set; }
        //public int ServiceID { get; set; }
        //public ContentVm TopMenu { get; set; }
        //public ContentVm Slider { get; set; }
        //public List<ContentVm> Sliders { get; set; }
        //public List<ContentVm> Testimonials { get; set; }
        //public EmailVM EmailVm { get; set; }
        //public ContentVm headers { get; set; }
        //public ContentVm Footer { get; set; }
        //public static ContentVm StaticSlider { get; set; }
        //public ContentVm contact { get; set; }
        //public ContentVm UniqueVariable { get; set; }
        #endregion







        public class SearchRequest
        {
            public string? CatId { get; set; }
            public string? SearchText { get; set; }
        }
        public static void ResetAllStaticsVariables()
        {


        }


    }
    public class StudentProfileVm
    {
        public int StudentProfileId { get; set; }
        public string? StudentName { get; set; }
        public string? FatherName { get; set; }
        public string? PhoneNo { get; set; }
        public string? StudentNic { get; set; }
        public string? FatherMobileNumber { get; set; }
        public string? FatherNic { get; set; }
        public string? FatherEmail { get; set; }
        public string? Email { get; set; }
        public int? StudentCategoryId { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int Age { get; set; }
        //public string PhotoBase64 { get; set; }
        public string? Description { get; set; }
        //public IFormFile? Photo { get; set; }
        //public byte[]? PhotoBytes { get; set; }
    }

    public class WebsiteSettingVm
    {
        public int? WebsiteSettingId { get; set; }
        public string? WebsiteTitle { get; set; }
        public string? WebsiteName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? ContentUrl { get; set; }
        public string? WebsiteLogo { get; set; }
        public string? FavIcon { get; set; }
    }
    public class WebSiteSettingsOtherVM
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }

    }
    public class Courses
    {
        public int? ActivityCourseId { get; set; }
        public int? CourseLevelId { get; set; }
        public string? LevelTitle { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? LongDescription { get; set; }
        public string? ShortName { get; set; }
        public string? BranchId { get; set; }
        public int? Avtive { get; set; }
        public byte[]? Image { get; set; }
    }
    public class EmailVM
    {

        public int WebsiteId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string? UserName { get; set; }
        public string? EmailSubject { get; set; }
        public string? EmailBody { get; set; }
        public string? MobileNumber { get; set; }
       
        // public string? TypeofBusiness { get; set; }
        //public string? MonthlyTransaction { get; set; }
        // public string? Question { get; set; }
        //  public string? UserWebsite { get; set; }
        //public string? ServiceApply { get; set; }
        public bool SendtoAdmin { get; set; }
        public bool SendtoUser { get; set; }
        public string EmailType { get; set; }
        public List<EmailAttachmentsVM> Attachments { get; set; }
    }
    public class EmailAttachmentsVM
    {
        public byte[] attachmentFile { get; set; }
    }
}
