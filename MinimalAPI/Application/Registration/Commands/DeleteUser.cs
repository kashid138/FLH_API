using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registration.Commands
{
    public class DeleteUser : IRequest  
    {
        public int userid { get; set; }
    }
}
