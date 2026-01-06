using Application.Abstractions;
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
    public class CreateTravelCardHandler : IRequestHandler<CreateTravelCard, TravelCard>
    {
        private readonly ITravelCardRepository _travelcardRepo;

        public CreateTravelCardHandler(ITravelCardRepository travelcardRepo)
        {
            _travelcardRepo = travelcardRepo;
        }

        public async Task<TravelCard> Handle(CreateTravelCard request, CancellationToken cancellationToken)
        {
            var newtravelcard = new TravelCard
            {
                description = request.Travelcarddescription,
                url = request.Travelcardurl,
                title = request.Travelcardtitle,
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            return await _travelcardRepo.CreateTravelcard(newtravelcard);
        }
    }
}
