using Application.Abstractions;
using Application.Carousel.Commands;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.CommandHandlers
{
    public class UpdateCarouselHandler : IRequestHandler<UpdateCarousel, CarouselN>
    {
        private readonly ICarouselRepository _carouselRepo;

        public UpdateCarouselHandler(ICarouselRepository carouselRepo)
        {
            _carouselRepo = carouselRepo;
        }

        public async Task<CarouselN> Handle(UpdateCarousel request, CancellationToken cancellationToken)
        {
            var carousel = await _carouselRepo.UpdateCarousel(request.url,request.title,request.description, request.CarouselId);
            return carousel;
        }

    }
}
