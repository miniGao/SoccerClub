using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models.ViewModels
{
    public class ManagePlayerModel
    {
        public IQueryable<Club> Clubs { get; set; }
        public IQueryable<Player> Players { get; set; }
        public Club Club { get; set; }
        public Club NewClub { get; set; }
        public Player Player { get; set; }
    }
}
