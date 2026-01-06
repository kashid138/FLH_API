using Application.Abstractions;
using Application.Carousel.Commands;
using Application.Registration.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registration.CommandHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        private readonly IRegistrationRepository _userRepo;

        public DeleteUserHandler(IRegistrationRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            await _userRepo.DeleteUser(request.userid);
        }
    }
}
