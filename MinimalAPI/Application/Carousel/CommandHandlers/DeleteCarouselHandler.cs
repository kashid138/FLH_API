using Application.Abstractions;
using Application.Carousel.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.CommandHandlers
{ 
    public class DeleteCarouselHandler : IRequestHandler<DeleteCarousel>
    {
        private readonly ICarouselRepository _carouselRepo;

        public DeleteCarouselHandler(ICarouselRepository carouselRepo)
        {
        _carouselRepo = carouselRepo;
        }

        public async Task Handle(DeleteCarousel request, CancellationToken cancellationToken)
        {
            await _carouselRepo.DeleteCarousel(request.CarouselId);
        }
    }
}
