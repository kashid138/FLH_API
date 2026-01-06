using Application.Abstractions;
using Application.Carousel.Commands;
using Application.TravelCards.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelCards.CommandHandlers
{
    public class UpdateTravelCardHandler : IRequestHandler<UpdateTravelCard, TravelCard>
    {
        private readonly ITravelCardRepository _travelcardRepo;

        public UpdateTravelCardHandler(ITravelCardRepository travelcardRepo)
        {
            _travelcardRepo = travelcardRepo;
        }

        public async Task<TravelCard> Handle(UpdateTravelCard request, CancellationToken cancellationToken)
        {
            var travelcard = await _travelcardRepo.UpdateTravelcard(request.url, request.title, request.description, request.TravelcardId);
            return travelcard;
        }

    }
}
