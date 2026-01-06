using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CarouselRepository : ICarouselRepository
    {
        private readonly LFHDBContext _context;

        public CarouselRepository(LFHDBContext context)
        {
            _context = context;
        }

        public async Task<CarouselN> CreateCarousel(CarouselN toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Carousel.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeleteCarousel(int CarouselId)
        {
            var Carousel = await _context.Carousel.FirstOrDefaultAsync(p => p.id == CarouselId);
            if (Carousel == null) return;

            _context.Carousel.Remove(Carousel);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CarouselN>> GetAllCarousels()
        {
            return await _context.Carousel.ToListAsync();
        }

        public async Task<CarouselN> GetCarouselsWithId(int CarouselId)
        {
            return await _context.Carousel.FirstOrDefaultAsync(p => p.id == CarouselId);

        }

        public async Task<CarouselN> UpdateCarousel(string Carouselurl, string Carouseltitle, string Carouseldescription, int CarouselId)
        {
            var Carousel = await _context.Carousel.FirstOrDefaultAsync(p => p.id == CarouselId);
            Carousel.LastModified = DateTime.Now;
            Carousel.url = Carouselurl;
            Carousel.title = Carouseltitle;
            Carousel.description = Carouseldescription;
            await _context.SaveChangesAsync();
            return Carousel;
        }
    }
}

