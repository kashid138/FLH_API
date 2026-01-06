using Domain.Models;
using MediatR;
 

namespace Application.Posts.Commands
{
    public class CreatePosts : IRequest<Post>
    {
        public string? PostContent { get; set; }
    }
}
