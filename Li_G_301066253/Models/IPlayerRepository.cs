using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }

        void AddPlayer(Player player);
        Player DeletePlayer(int playerId);
        Player UpdatePlayer(Player player);
    }
}
