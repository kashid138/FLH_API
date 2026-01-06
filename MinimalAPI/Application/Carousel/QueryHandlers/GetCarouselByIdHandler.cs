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
    public class GetCarouselByIdHandler : IRequestHandler<GetCarouselById, CarouselN>
    {
        private readonly ICarouselRepository _carouselRepo;
        public GetCarouselByIdHandler(ICarouselRepository carouselRepo)
        {
            _carouselRepo = carouselRepo;
        }
        public async Task<CarouselN> Handle(GetCarouselById request, CancellationToken cancellationToken)
        {
            return await _carouselRepo.GetCarouselsWithId(request.CarouselId);
        }
    }
}
