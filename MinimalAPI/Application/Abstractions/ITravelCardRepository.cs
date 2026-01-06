using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ITravelCardRepository
    {
        Task<ICollection<TravelCard>> GetAllTravelcards();
        Task<TravelCard> GetTravelcardsWithId(int TravelcardlId);

        Task<TravelCard> CreateTravelcard(TravelCard toCreate);

        Task<TravelCard> UpdateTravelcard(string Travelcardurl, string Travelcardtitle, string Travelcarddescription, int TravelcardId);

        Task DeleteTravelcard(int TravelcardId);



    }
}
