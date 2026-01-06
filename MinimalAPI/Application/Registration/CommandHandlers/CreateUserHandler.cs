using Application.Abstractions;
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
    public class CreateUserHandler : IRequestHandler<CreateUser, UserRegistration>
    {
        private readonly IRegistrationRepository _usersRepo;

        public CreateUserHandler(IRegistrationRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public async Task<UserRegistration> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var newUser = new UserRegistration
            { 
                firstName = request.firstName,
                lastName = request.lastName,
                contact =   request.contact,
                email = request.email,
                password = request.password,
                usertype = "USER"
            };
            return await _usersRepo.CreateUser(newUser);
        }
    }
}
