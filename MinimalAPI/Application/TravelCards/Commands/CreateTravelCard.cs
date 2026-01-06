using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelCards.Commands
{
    public class CreateTravelCard : IRequest<TravelCard>
    {
        public int Id { get; set; }
        public string Travelcardurl { get; set; }
        public string Travelcardtitle { get; set; }
        public string Travelcarddescription { get; set; }

        //public string? Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
