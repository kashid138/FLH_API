using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VisitorsCount.Queries
{
    //public class GetVisitorCountByDate : IRequest<ICollection<VisitorsCountModel>>
   public class GetVisitorsByDateCommand : IRequest<List<VisitorsCountModel>>
    {
    }
}
