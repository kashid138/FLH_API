using Domain.Models;

namespace Minimal_Api.Filters
{
    public class UserRegistrationValidationsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var user = context.GetArgument<UserRegistration>(1);
            if (string.IsNullOrEmpty(user.firstName))
                return await Task.FromResult(Results.BadRequest("First Name Not Valid"));
            else if (string.IsNullOrEmpty(user.lastName))
                return await Task.FromResult(Results.BadRequest("Last Name Not Valid"));
            else if (string.IsNullOrEmpty(user.contact))
                return await Task.FromResult(Results.BadRequest("Contact Not Valid"));
            else if (string.IsNullOrEmpty(user.email))
                return await Task.FromResult(Results.BadRequest("Email Not Valid"));
            return await next(context);
        }
    }
}
