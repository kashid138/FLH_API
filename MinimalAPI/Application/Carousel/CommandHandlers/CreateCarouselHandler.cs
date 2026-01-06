using Application.Abstractions;
using Application.Carousel.Commands;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.CommandHandlers
{
    public class CreateCarouselHandler : IRequestHandler<CreateCarousel, CarouselN>
    {
        private readonly ICarouselRepository _carouselRepo;

        public CreateCarouselHandler(ICarouselRepository carouselRepo)
        {
            _carouselRepo = carouselRepo;
        }

        public async Task<CarouselN> Handle(CreateCarousel request, CancellationToken cancellationToken)
        {
            var newCarousel = new CarouselN
            {
                description = request.Carouseldescription,
                url = request.Carouselurl,
                title = request.Carouseltitle,
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now
            };

            return await _carouselRepo.CreateCarousel(newCarousel);
        }
    }
}
