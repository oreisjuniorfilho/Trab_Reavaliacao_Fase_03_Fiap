using MvcBlogNoticias.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MvcBlogNoticias.Web.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

string apiBaseAddress = builder.Configuration["ApiSettings:ApiUrl"];

string apiKey = builder.Configuration["ApiSettings:ApiKey"]; // Obtém a chave de autenticação

builder.Services.AddHttpClient<INoticiaService, NoticiaService>(client =>
{ 
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    client.BaseAddress = new Uri(apiBaseAddress);
});

builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MvcBlogNoticiasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcBlogNoticiasContext")));

builder.Services.AddApplicationInsightsTelemetry();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
