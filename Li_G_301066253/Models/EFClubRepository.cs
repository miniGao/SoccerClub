using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public class EFClubRepository : IClubRepository
    {
        private ApplicationDbContext context;
        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Club> Clubs => context.Clubs.Include(context => context.Players);

        public void AddClub(Club club)
        {
            context.Add(club);
            context.SaveChanges();
        }

        public Club DeleteClub(int clubId)
        {
            Club dbClub = context.Clubs.Include(context => context.Players).FirstOrDefault(c => c.ClubID == clubId);
            if (dbClub != null)
            {
                context.Clubs.Remove(dbClub);
                context.SaveChanges();
            }
            return dbClub;
        }

        public Club EditClub(Club club)
        {
            Club dbClub = context.Clubs.FirstOrDefault(c => c.ClubID == club.ClubID);
            if (dbClub != null)
            {
                dbClub.Name = club.Name;
                dbClub.Information = club.Information;
                dbClub.Address = club.Address;
                dbClub.Phone = club.Phone;
            }
            context.SaveChanges();
            return dbClub;
        }
    }
}
