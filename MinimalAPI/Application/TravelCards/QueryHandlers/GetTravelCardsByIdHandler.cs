using Application.Abstractions;
using Application.TravelCards.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelCards.QueryHandlers
{

    public class GetTravelCardsByIdHandler : IRequestHandler<GetTravelCardsById, TravelCard>
    {
        private readonly ITravelCardRepository _travelcardRepo;
        public GetTravelCardsByIdHandler(ITravelCardRepository travelcard)
        {
            _travelcardRepo = travelcard;
        }
        public async Task<TravelCard> Handle(GetTravelCardsById request, CancellationToken cancellationToken)
        {
            return await _travelcardRepo.GetTravelcardsWithId(request.TravelcardId);
        }
    }
}
