using Auth.API.Infrastructure.Extensions;
using Auth.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var appAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
var appConnectionString = builder.Configuration.GetConnectionString("ApplicationDB");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructure(appConnectionString, appAssemblyName);
builder.Services.AddAppIdentity();
builder.Services.AddAppIdentityServer(appConnectionString, appAssemblyName);


var app = builder.Build();
app.MigrateDb();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
