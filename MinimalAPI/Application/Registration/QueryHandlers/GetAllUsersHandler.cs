using Application.Abstractions;
using Application.Carousel.Queries;
using Application.Registration.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registration.QueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, ICollection<UserRegistration>>
    {
        private readonly IRegistrationRepository _userRepo;

        public GetAllUsersHandler(IRegistrationRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<ICollection<UserRegistration>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepo.GetAllUsers();
        }
    }
}
