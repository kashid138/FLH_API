using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registration.Commands
{
    public class CreateUser : IRequest<UserRegistration>
    {
        public int userid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string usertype { get; set; }

        public string password { get; set; }


    }
}
