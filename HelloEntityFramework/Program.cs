using HelloEntityFramework.Data;
using HelloEntityFramework.Localizers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddMvcLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddSingleton<DatabaseStringLocalizerFactory>();
builder.Services.AddSingleton<IStringLocalizerFactory>(provider => provider.GetRequiredService<DatabaseStringLocalizerFactory>());
builder.Services.AddRequestLocalization(options =>
{
    options.AddSupportedCultures("en-US", "nl", "fr");
    options.AddSupportedUICultures("en-US", "nl", "fr");
});

builder.Services.AddDbContext<HelloEntityFrameworkContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<UserRepository>();

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
app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
