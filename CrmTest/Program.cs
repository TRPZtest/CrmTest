using CrmTest.Data.ApplicationIdentity;
using CrmTest.Data.ApplicationIdentityData;
using CrmTest.Data.CrmData;
using CrmTest.Identity;
using CrmTest.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
    options.UseSqlServer(connectionString)
   );
builder.Services.AddDbContext<CrmContext>(options =>
    options.UseSqlServer(connectionString)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.Password.RequireNonAlphanumeric = false)
    .AddRoles<ApplicationRole>() 
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

builder.Services.AddControllersWithViews(); 

builder.Services.AddScoped<EmployeesRepository>();
builder.Services.AddScoped<AddEditEmployeeModelService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<AddUserService>();

var app = builder.Build();

await IdentityConfiguration.AddRoles(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
