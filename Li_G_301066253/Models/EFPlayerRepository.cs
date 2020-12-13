using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Player> Players => context.Players;

        public void AddPlayer(Player player)
        {
            context.Add(player);
            context.SaveChanges();
        }

        public Player DeletePlayer(int playerId)
        {
            Player player = context.Players.FirstOrDefault(p => p.PlayerID == playerId);
            if (player != null)
            {
                context.Players.Remove(player);
                context.SaveChanges();
            }
            return player;
        }

        public Player UpdatePlayer(Player player)
        {
            Player dbPlayer = context.Players.FirstOrDefault(p => p.PlayerID == player.PlayerID);
            if (dbPlayer != null)
            {
                dbPlayer.Name = player.Name;
                dbPlayer.Age = player.Age;
                dbPlayer.Position = player.Position;
            }
            context.SaveChanges();
            return dbPlayer;
        }
    }
}
