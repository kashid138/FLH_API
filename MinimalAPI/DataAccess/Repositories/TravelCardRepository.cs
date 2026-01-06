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
    public class TravelCardRepository: ITravelCardRepository
    {
        private readonly LFHDBContext _context;

        public TravelCardRepository(LFHDBContext context)
        {
            _context = context;
        }

        public async Task<TravelCard> CreateTravelcard(TravelCard toCreate)
        {
            toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.Travelcard.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeleteTravelcard(int TravelcardId)
        {
            var Travelcard = await _context.Travelcard.FirstOrDefaultAsync(p => p.id == TravelcardId);
            if (Travelcard == null) return;

            _context.Travelcard.Remove(Travelcard);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TravelCard>> GetAllTravelcards()
        {
            //return await _context.Travelcard.ToListAsync();
            return await _context.Travelcard
            .OrderByDescending(tc => tc.id)
            .ToListAsync();

        }

        public async Task<TravelCard> GetTravelcardsWithId(int TravelcardlId)
        {
            return await _context.Travelcard.FirstOrDefaultAsync(p => p.id == TravelcardlId);
        }

        public async Task<TravelCard> UpdateTravelcard(string Travelcardurl, string Travelcardtitle, string Travelcarddescription, int TravelcardId)
        {
            var travel = await _context.Travelcard.FirstOrDefaultAsync(p => p.id == TravelcardId);
            travel.LastModified = DateTime.Now;
            travel.url = Travelcardurl;
            travel.title = Travelcardtitle;
            travel.description = Travelcarddescription;
            await _context.SaveChangesAsync();
            return travel;
        }
    }
}
