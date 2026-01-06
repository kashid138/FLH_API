using Application.Abstractions;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Minimal_Api.Abstractions;
using Domain.Models;
using Minimal_Api.EndpointDefinations;

namespace Minimal_Api.Extensions
{
    public static class MinimalApiExtentions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<LFHDBContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICarouselRepository, CarouselRepository>();
            builder.Services.AddScoped<ITravelCardRepository, TravelCardRepository>();
            builder.Services.AddScoped<IRegistrationRepository, UserRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IVisitorRepository, VisitorsRepository>();
            builder.Services.AddScoped<IMailRepository, MailRepository>();
            builder.Services.AddScoped<IEndpointDefinations, PostEndpointDefinations>();



        }

        public static void RegisterEndpointDefinations( this WebApplication app)
        {
            var endpointDefinations = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinations))
                && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefinations>();
            foreach(var endpointDef in endpointDefinations)
            {
                endpointDef.RegisterEndpoints(app);
            }
        }
   
    }
}
