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
    public class GetUserByIdHandler : IRequestHandler<GetUserByID, UserRegistration>
    {
        private readonly IRegistrationRepository _userRepo;
        public GetUserByIdHandler(IRegistrationRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserRegistration> Handle(GetUserByID request, CancellationToken cancellationToken)
        {
            return await _userRepo.GetUserWithId(request.userid);
        }
    }
}
