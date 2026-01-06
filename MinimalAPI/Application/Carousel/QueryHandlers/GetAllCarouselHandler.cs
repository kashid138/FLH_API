using Application.Abstractions;
using Application.Carousel.Queries;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.QueryHandlers
{
    public class GetAllCarouselHandler  : IRequestHandler<GetAllCarousel, ICollection<CarouselN>>
    {
        private readonly ICarouselRepository _carouselRepo;
        public GetAllCarouselHandler(ICarouselRepository carouselRepo)
        {
            _carouselRepo = carouselRepo;
        }

        public async Task<ICollection<CarouselN>> Handle(GetAllCarousel request, CancellationToken cancellationToken)
        {
            return await _carouselRepo.GetAllCarousels();
        }
    }
}
