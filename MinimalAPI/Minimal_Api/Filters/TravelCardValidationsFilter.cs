using Domain.Models;

namespace Minimal_Api.Filters
{
    public class TravelCardValidationsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var travelcard = context.GetArgument<TravelCard>(1);
            if (string.IsNullOrEmpty(travelcard.title))
                return await Task.FromResult(Results.BadRequest("title Not Valid"));
            else if (string.IsNullOrEmpty(travelcard.url))
                return await Task.FromResult(Results.BadRequest("url Not Valid"));
            else if (string.IsNullOrEmpty(travelcard.description))
                return await Task.FromResult(Results.BadRequest("description Not Valid"));
            return await next(context);
        }
    }
}
