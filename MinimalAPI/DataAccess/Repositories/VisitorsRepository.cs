using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VisitorsRepository : IVisitorRepository
    {
        private readonly LFHDBContext _context;

        public VisitorsRepository(LFHDBContext context)
        {
            _context = context;
        }

        public async Task<VisitorsCountModel> CreateOrUpdateVisitorCount(string userIdentifier)
        {
            var currentDate = DateTime.Today;
            var currentVisitTimestamp = DateTime.Now;

            // Check if the visitor already has a record today (based on user identifier)
            var lastVisit = await _context.Visitors
                .Where(v => v.UserIdentifier == userIdentifier && v.Date == currentDate)
                .OrderByDescending(v => v.LastVisitTimestamp)
                .FirstOrDefaultAsync();

            // If no visit is found, or if the last visit was more than 2 hours ago, it's a new visit
            if (lastVisit == null || (currentVisitTimestamp - lastVisit.LastVisitTimestamp).TotalHours > 1)
            {
                var visitorCount = await _context.Visitors.FirstOrDefaultAsync(v => v.Date == currentDate);
                if (visitorCount == null)
                {
                    visitorCount = new VisitorsCountModel
                    {
                        Date = currentDate,
                        Count = 1,
                    };
                    _context.Visitors.Add(visitorCount);
                }
                else
                {
                    visitorCount.Count++;
                    _context.Visitors.Update(visitorCount);
                }

                // Log the new visit with timestamp and user identifier
                _context.Visitors.Add(new VisitorsCountModel
                {
                    UserIdentifier = userIdentifier,
                    Date = currentDate,
                    LastVisitTimestamp = currentVisitTimestamp
                });

                await _context.SaveChangesAsync();
                return visitorCount;
            }

            // If the visit is within the 2-hour window, don't increment the count
            return lastVisit;
        }

        //public Task<VisitorsCountModel> CreateOrUpdateVisitorCount()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<VisitorsCountModel>> GetAllVisitorsByDate()

        {
            return await _context.Visitors.OrderBy(v => v.Date).ToListAsync();
        }
 
    }
}
