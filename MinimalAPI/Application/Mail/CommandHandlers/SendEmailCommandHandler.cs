using Application.Abstractions;
using Application.Mail.Commands;
using Domain.Models;
using MediatR;
using System.Threading;

using MediatR;
using System.Threading;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly IMailRepository _mailRepo;

    public SendEmailCommandHandler(IMailRepository mailRepo)
    {
        _mailRepo = mailRepo;
    }

    public Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var mail = new SendMail
        {
            From = request.From,
            To = request.To,
            Subject = request.Subject,
            Body = request.Body
        };

        _mailRepo.SendEmailAsync(mail);

        // Return Task.FromResult(Unit.Value) to complete the Task
        return Task.FromResult(Unit.Value);
    }


}
