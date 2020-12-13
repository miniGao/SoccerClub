using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        [Required(ErrorMessage = "Please enter club name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter club information")]
        public string Information { get; set; }
        [Required(ErrorMessage = "Please enter club address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter club phone number")]
        public string Phone { get; set; }
        public List<Player> Players { get; set; }
    }
}
