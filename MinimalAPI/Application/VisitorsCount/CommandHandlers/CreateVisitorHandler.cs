using Application.Abstractions;
using Application.Registration.Commands;
using Application.TravelCards.Commands;
using Application.Visitors.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VisitorsCount.CommandHandlers
{
    public class CreateVisitorHandler : IRequestHandler<CreateVisitorCount, VisitorsCountModel>
    {
        private readonly IVisitorRepository _visitorRepo;

        public CreateVisitorHandler(IVisitorRepository visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }
        //public async Task<VisitorsCountModel> Handle(CreateVisitorCount request, CancellationToken cancellationToken)
        //{
        //    return await _visitorRepo.CreateOrUpdateVisitorCount(userIdentifier);
        //}


        public async Task<VisitorsCountModel> Handle(CreateVisitorCount request, CancellationToken cancellationToken)
        {
            // Pass the user identifier from the request to the repository
            return await _visitorRepo.CreateOrUpdateVisitorCount(request.UserIdentifier);
        }

    }
}
