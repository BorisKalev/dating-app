﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjFinRBEM.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjFinRBEMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjFinRBEMContext") ?? throw new InvalidOperationException("Connection string 'ProjFinRBEMContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(10); options.Cookie.HttpOnly = true; options.Cookie.IsEssential = true; });
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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
