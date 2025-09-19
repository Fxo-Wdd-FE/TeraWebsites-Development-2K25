using System.Net.Mail;
using System.Net;
using EmailServices.Repository;
using IlmAcademy.Repository;
using IlmAcademy.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ContentRepository>();
builder.Services.AddScoped<WebsiteSettingRepository>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<SmtpClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new SmtpClient
    {
        Host = config.GetValue<string>("SmtpSettings:Host"),
        Port = config.GetValue<int>("SmtpSettings:Port"),
        Credentials = new NetworkCredential(
            config.GetValue<string>("SmtpSettings:Username"),
            config.GetValue<string>("SmtpSettings:Password")
        ),
        EnableSsl = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
