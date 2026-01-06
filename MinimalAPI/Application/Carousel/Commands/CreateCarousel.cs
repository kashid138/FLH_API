using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Carousel.Commands
{
    public class CreateCarousel : IRequest<CarouselN>
    {
        public int Id { get; set; }
        public string Carouselurl { get; set; }
        public string Carouseltitle { get; set; }
        public string Carouseldescription { get; set; }
        
        //public string? Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

    }
}
