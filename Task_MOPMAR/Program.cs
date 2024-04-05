using OfficeOpenXml;
using System.Reflection;
namespace Task_MOPMAR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var C_S = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<ApplicationDbContext>
                 (options => options.UseSqlServer(C_S));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
            options => options.Password.RequireDigit = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
