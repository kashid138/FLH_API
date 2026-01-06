using Application.Abstractions;
using Application.TravelCards.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelCards.CommandHandlers
{
    public class DeleteTravelCardHandler : IRequestHandler<DeleteTravelCard>
    {
        private readonly ITravelCardRepository _travelcardRepo;

        public DeleteTravelCardHandler(ITravelCardRepository travelcardRepo)
        {
            _travelcardRepo = travelcardRepo;
        }

        public async Task Handle(DeleteTravelCard request, CancellationToken cancellationToken)
        {
            await _travelcardRepo.DeleteTravelcard(request.TravelcardId);
        }
    }
}
