using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public interface IClubRepository
    {
        IQueryable<Club> Clubs { get; }

        void AddClub(Club club);
        Club EditClub(Club club);
        Club DeleteClub(int clubId);
    }
}
