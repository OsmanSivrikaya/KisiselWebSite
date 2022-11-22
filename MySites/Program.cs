using MySites.Modules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Service.Mapping;
using System.Reflection;
using MySites.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region FluentValidation
//builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(AbstractValidator<>)));

builder.Services.AddControllersWithViews().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

/*
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
*/
#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder => ContainerBuilder.RegisterModule(new ServiceModules()));
#endregion

#region Session
builder.Services.AddSession();
#endregion

#region Authentication Ext
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; //Authentication olunan kýsým
        options.AccessDeniedPath = "/denied"; //hatalý eriþim denemesinde açýlan sayfa adý
        options.Events = new CookieAuthenticationEvents()
        {
            OnSignedIn = async context =>
            {
                await Task.CompletedTask;
            },
            OnSigningOut = async context =>
            {
                await Task.CompletedTask;
            },
            OnValidatePrincipal = async context =>
            {
                await Task.CompletedTask;
            }

        };
    });
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));
#endregion


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
app.UseAuthentication();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
