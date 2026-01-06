using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TravelCards.Commands
{
    public class UpdateTravelCard : IRequest<TravelCard>
    {
        public int TravelcardId { get; set; }
        public string? url { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }
}
