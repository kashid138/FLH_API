using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Minimal_Api.Filters
{
    public class PostValidationsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1);
            if (string.IsNullOrEmpty(post.Content))
                return await Task.FromResult(Results.BadRequest("Post Not Valid"));
            return await next(context);
        }
    }
}
