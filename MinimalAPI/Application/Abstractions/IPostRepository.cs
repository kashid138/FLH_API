using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts();
        Task<Post> GetPostsWithId(int postId);

        Task<Post> CreatePost(Post toCreate);

        Task<Post> UpdatePost(string PostContent , int postId);

        Task DeletePost(int postId);


    }
}
