using InertiaCore.Extensions;
using Spark.Library.Environment;
using Spark.Library.Config;
using Spark.Templates.Inertiajs.Application.Startup;
using Spark.Templates.Inertiajs.Application.Middleware;

EnvManager.LoadConfig();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupSparkConfig();

builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseInertia();
app.UsePageNotFoundMiddleware();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseInertiaSharedAuthProps();

app.Services.RegisterScheduledJobs();
app.Services.RegisterEvents();

app.Run();
