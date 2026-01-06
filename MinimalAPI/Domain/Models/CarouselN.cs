using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CarouselN
    {
        public int id { get; set; }

        public string? url { get; set; }

        public string? title { get; set; }
        public string? description { get; set; }

        //public string? Image { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }

 


    }
}
