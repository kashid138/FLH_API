using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserRegistration
    {
        [Key]
        public int userid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }
        public string email { get; set; }

        public string usertype { get; set; }

        public string password { get; set; }


        public string? Message { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

    }
}
