using Application.Carousel.Commands;
using Application.Mail.Commands;
using Application.Posts.Commands;
using Application.Registration.Commands;
using Application.TravelCards.Commands;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Minimal_Api.Extensions;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // Use in-memory cache for session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout after 30 minutes of inactivity
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("MailSettings"));
builder.RegisterServices();
//builder.Services.AddMediatR(typeof(CreatePosts));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(
   typeof(CreatePosts).Assembly,
   typeof(CreateCarousel).Assembly,
   typeof(CreateTravelCard).Assembly,
   typeof(CreateUser).Assembly,
   typeof(SendEmailCommandHandler).Assembly
));

builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowAll",
 builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//        options.RoutePrefix = string.Empty;  
//    });
//}


app.UseSession(); // Enable session middleware
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "Minimal_Api", "Docs")),
    RequestPath = "/docs"
});


app.UseCors("AllowAll");

//app.Use(async (ctx, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (Exception)
//    {
//        ctx.Response.StatusCode = 500;
//        await ctx.Response.WriteAsync("An Error Ocurred");
//    }
//});

app.UseHttpsRedirection();
app.RegisterEndpointDefinations();
app.Run();
