using Application.Abstractions;
using Application.Posts.Queries;
using Application.TravelCards.Queries;
using Application.VisitorsCount.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VisitorsCount.QueryHandlers
{
    public class GetVisitorsByDateHandler : IRequestHandler<GetVisitorsByDateCommand, List<VisitorsCountModel>>
    {
        private readonly IVisitorRepository _visitorRepo;

        public GetVisitorsByDateHandler(IVisitorRepository visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }

        public async Task<List<VisitorsCountModel>> Handle(GetVisitorsByDateCommand request, CancellationToken cancellationToken)
        {
            return await _visitorRepo.GetAllVisitorsByDate();
        }
    }
}
