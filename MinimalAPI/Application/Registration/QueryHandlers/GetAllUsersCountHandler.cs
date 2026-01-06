using Application.Abstractions;
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
    public class GetAllUsersCountHandler : IRequestHandler<GetAllUsersCount, int>
    {
        private readonly IRegistrationRepository _userRepo;

        public GetAllUsersCountHandler(IRegistrationRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<int> Handle(GetAllUsersCount request, CancellationToken cancellationToken)
        {
            return await _userRepo.GetAllUsersCount();
        }
    }
}
