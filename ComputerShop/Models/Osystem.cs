using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models
{
    public class Osystem
    {
        [Key]
        [MaxLength(36)]


        public Guid Id { get; set; }
        public string name { get; set;  }
        public int Version { get; set; }

        public DateTime RegisterTime { get; set;  }

        public DateTime UpDateTime { get; set;  }

    }
}
