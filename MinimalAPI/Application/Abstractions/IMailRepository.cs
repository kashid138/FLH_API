using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Abstractions
{
    public interface IMailRepository
    {
        //Task SendEmailAsync(SendMail mail);

        Task SendEmailAsync(SendMail sm);



    }
}
