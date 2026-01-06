using Application.Abstractions;
using Application.Login.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Login.CommandHandlers
{
    public class CheckLoginHandler : IRequestHandler<CheckLogin, UserLogin>
    {
        private readonly ILoginRepository _userRepo;
        public CheckLoginHandler(ILoginRepository userRepo)
        {
            _userRepo = userRepo;
        }

        //public async Task<UserLogin> Handle(CheckLogin request, CancellationToken cancellationToken)
        //{
        //    var checkuser = new CheckLogin
        //    {
        //        Email = request.Email,
        //        Contact = request.Contact
        //    };

        //    return await _userRepo.CheckLogin(checkuser);
        //}

        public async Task<UserLogin> Handle(CheckLogin request, CancellationToken cancellationToken)
        {
            var checkuser = new CheckLogin
            {
                Email = request.Email,
                Password = request.Password
            };

            return await _userRepo.CheckLogin(checkuser.Email, checkuser.Password);
        }


    }
}
