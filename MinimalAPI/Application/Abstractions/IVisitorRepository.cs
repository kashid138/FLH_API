using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IVisitorRepository
    {
        Task<List<VisitorsCountModel>> GetAllVisitorsByDate();
        //Task<Visitors> GetCarouselsWithId(int id);

        Task<VisitorsCountModel> CreateOrUpdateVisitorCount(string userIdentifier);


    }
}
