using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.Queries
{
    public class GetCarouselById : IRequest<CarouselN>
    {
        public int CarouselId { get; set; }
    }
}
