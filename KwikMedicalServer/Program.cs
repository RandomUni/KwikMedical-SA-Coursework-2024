using KwikMedicalServer.Data;
using KwikMedicalServer.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;


/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.UseResponseCompression();

app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7059")
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<KwikMedicalHub>("/kwikmedicalhub");
});

//app.MapHub<KwikMedicalHub>("/kwikmedicalhub");
app.MapFallbackToPage("/_Host");

app.Run();

*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("KwikDB");


builder.Services.AddDbContextFactory<KwikUserContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContextFactory<MedicalRequestResponseContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();


app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:7059")
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<KwikMedicalHub>("/kwikmedicalhub");
});


app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();