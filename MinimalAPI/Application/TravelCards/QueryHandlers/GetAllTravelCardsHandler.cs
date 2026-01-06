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

    public class GetAllTravelCardsHandler : IRequestHandler<GetAllTravelCards, ICollection<TravelCard>>
    {
        private readonly ITravelCardRepository _travelcardRepo;
        public GetAllTravelCardsHandler(ITravelCardRepository travelcardRepo)
        {
            _travelcardRepo = travelcardRepo;
        }

        public async Task<ICollection<TravelCard>> Handle(GetAllTravelCards request, CancellationToken cancellationToken)
        {
            return await _travelcardRepo.GetAllTravelcards();
        }
    }
}
