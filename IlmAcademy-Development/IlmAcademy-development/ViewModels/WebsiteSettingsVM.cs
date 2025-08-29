using Anyweb;

namespace IlmAcademy.ViewModels
{
    public class WebsiteSettingsVM
    {
    }
    public class WebsiteRequestVM
    {
        public int? WebsiteId { get; set; }
        public string? Slug { get; set; }

        public List<string> Slugs { get; set; }
    }
    public class BlogRequestVM
    {
        public int? WebsiteId { get; set; }
        public string? Slug { get; set; }

        public List<string> Slugs { get; set; }
        public List<string> SettingsName { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string CategorySlug { get; set; }
        public string TypeSlug { get; set; }
        public bool isCategoryContent { get; set; } = false;

    }
    public class WebsiteRequestOVM
    {
        public int? WebsiteId { get; set; }
        public string? Slug { get; set; }

        public List<string> Slugs { get; set; }
        public List<string> settingsName { get; set; }
    }
    public class WebsiteSettingResponseVM
    {
        public string Status { get; set; }
        public string statusCode { get; set; }
        public string Message { get; set; }
        public WebsiteSettingVm websiteSetting { get; set; }
        public List<WebSiteSettingsOtherVM> websiteOtherSettings { get; set; }

    }
    public class websiteOtherSettingss
    {
        //public string Status { get; set; }
        //public string statusCode { get; set; }
        //public string Message { get; set; }
        public List<WebSiteSettingsOtherVM> websiteOtherSettings { get; set; }
    }
    public class WebsiteContentResponseVM
    {

        public string Status { get; set; }
        public string statusCode { get; set; }
        public string Message { get; set; }
        public ContentVm contentItem { get; set; }
        public List<ContentVm> contentItems { get; set; }
        public List<Courses> Courses { get; set; }
    

    }
    public class StudentCategories
    {
        public int? StudentCategoryId { get; set; }
        public string? CategoryTitle { get; set; }
        public int? Active { get; set; }
        public int? BrachId { get; set; }
    }
    public class ResponseCoursesVm
    {

        public string Status { get; set; }
        public string statusCode { get; set; }
        public string Message { get; set; }
        public List<Courses> Courses { get; set; }
        public List<StudentCategories> Categories { get; set; }
        public Courses Course { get; set; }
        public StudentProfileVm StudentProfile { get; set; }
        public int StudentProfileId { get; set; }

    }
    public class ContentMenuLevel
    {
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public int? ParentMenuId { get; set; }
        public int Level { get; set; }
        public string ParentMenuTitle { get; set; }
        public string Link { get; set; }
        public List<ContentMenuLevel> Children { get; set; } = new();
    }
    public class ThemeSettingsRequest
    {
        public int? WebsiteId { get; set; }
        public string? Group { get; set; }
        public string? Title { get; set; }
    }
    public class ThemeResponseVM
    {

        public string Status { get; set; }
        public string statusCode { get; set; }
        public string Message { get; set; }
        public string? Value { get; set; }
        public List<ContentMenuLevel> Menu { get; set; }

    }
    public class VisitorLogRequestVM
    {
        public int? websiteId { get; set; }
        public string? Url { get; set; }
        public int? ContactId { get; set; }
        public string? IpAddress { get; set; }
        public string? DeviceName { get; set; }
        public string? Browser { get; set; }
        public string? SessionId { get; set; }
    }

}
