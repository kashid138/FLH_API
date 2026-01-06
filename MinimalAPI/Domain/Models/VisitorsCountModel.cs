using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VisitorsCountModel
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }            // The date of the visit
        public int? Count { get; set; }                // The total count for the day
        public string? UserIdentifier { get; set; }    // Unique identifier for the user (e.g., session ID or IP)
        public DateTime LastVisitTimestamp { get; set; }  // Timestamp of the last visit
    }


    public class UsersCountModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }

}
