using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Visitors.Commands
{
    public class CreateVisitorCount : IRequest<VisitorsCountModel>
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Count { get; set; }
        public string? UserIdentifier { get; set; }    // Unique identifier for the user (e.g., session ID or IP)

    }
}
