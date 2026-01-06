using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IRegistrationRepository
    {
        Task<ICollection<UserRegistration>> GetAllUsers();
        Task<UserRegistration> GetUserWithId(int userId);

        Task<UserRegistration> CreateUser(UserRegistration toCreate);

        Task DeleteUser(int userId);

        Task<int> GetAllUsersCount();

    }
}
