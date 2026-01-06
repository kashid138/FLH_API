using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Minimal_Api.Filters
{
    public class CarouselValidationsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var carousel = context.GetArgument<CarouselN>(1);
            if (string.IsNullOrEmpty(carousel.title))
                return await Task.FromResult(Results.BadRequest("title Not Valid"));
            else if (string.IsNullOrEmpty(carousel.url))
                return await Task.FromResult(Results.BadRequest("url Not Valid"));
            else if (string.IsNullOrEmpty(carousel.description))
                return await Task.FromResult(Results.BadRequest("description Not Valid"));
            return await next(context);
        }
    }
}
