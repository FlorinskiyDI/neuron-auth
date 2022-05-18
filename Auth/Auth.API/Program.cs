using Auth.API.Infrastructure;
using Auth.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var appAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
var appConnectionString = builder.Configuration.GetConnectionString("ApplicationDB");

// Add services to the container.
//builder.Services.AddControllers();

builder.Services.AddInfrastructure(appConnectionString, appAssemblyName);
builder.Services.AddAppIdentity();
builder.Services.AddAppIdentityServer(appConnectionString, appAssemblyName);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MigrateDb();

Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAppIdentityServer();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
