using FirstWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FirstWebMVC.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext và cấu hình chuỗi kết nối
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext") ??
        throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// Đăng ký Identity với ApplicationUser
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();  // Đảm bảo thêm Entity Framework Stores

// Đăng ký các dịch vụ khác cho MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình các middleware trong pipeline HTTP request
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Cấu hình HSTS cho các môi trường sản phẩm
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();  // Đảm bảo gọi UseAuthentication
app.UseAuthorization();   // Đảm bảo gọi UseAuthorization

// Cấu hình route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
