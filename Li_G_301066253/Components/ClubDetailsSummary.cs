using Li_G_301066253.Models;
using Li_G_301066253.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Components
{
    public class ClubDetailsSummary : ViewComponent
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;
        public ClubDetailsSummary(IClubRepository clubRepo, IPlayerRepository playerRepo)
        {
            clubRepository = clubRepo;
            playerRepository = playerRepo;
        }
        public IViewComponentResult Invoke(int clubId)
        {
            return View(new PlayersViewModel
            {
                PlayerQty = playerRepository.Players.Where(p => p.ClubID == clubId).Count(),
                ForwardQty = playerRepository.Players.Where(p => p.ClubID == clubId && p.Position == "Forward").Count(),
                MidfieldQty = playerRepository.Players.Where(p => p.ClubID == clubId && p.Position == "Midfielder").Count(),
                DefenderQty = playerRepository.Players.Where(p => p.ClubID == clubId && p.Position == "Defender").Count(),
                GoalKeeperQty = playerRepository.Players.Where(p => p.ClubID == clubId && p.Position == "Goalkeeper").Count()
            });
        }
    }
}
