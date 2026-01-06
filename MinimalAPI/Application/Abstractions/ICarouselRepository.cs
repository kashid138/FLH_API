using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Abstractions
{
    public interface ICarouselRepository
    {
        Task<ICollection<CarouselN>> GetAllCarousels();
        Task<CarouselN> GetCarouselsWithId(int id);

        Task<CarouselN> CreateCarousel(CarouselN toCreate);

        Task<CarouselN> UpdateCarousel(string Carouselurl, string Carouseltitle, string Carouseldescription, int CarouselId);   

        Task DeleteCarousel(int CarouselId);
    }
}
