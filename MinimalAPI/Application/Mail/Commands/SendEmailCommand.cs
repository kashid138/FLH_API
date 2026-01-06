using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mail.Commands
{
    public class SendEmailCommand : IRequest<Unit>
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
    }

}
