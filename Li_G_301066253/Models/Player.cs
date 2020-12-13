using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Please enter player name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter player age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter player position")]
        public string Position { get; set; }
        public int ClubID { get; set; }
    }
}
