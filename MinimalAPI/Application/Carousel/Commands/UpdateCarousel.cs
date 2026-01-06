using MediatR;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Carousel.Commands
{
    public class UpdateCarousel : IRequest<CarouselN>
    {
        public int CarouselId { get; set; }
        public string? url { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }
}
