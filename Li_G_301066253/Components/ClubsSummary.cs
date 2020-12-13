using Li_G_301066253.Models;
using Li_G_301066253.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Li_G_301066253.Components
{
    public class ClubsSummary : ViewComponent
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;
        public ClubsSummary(IClubRepository clubRepo, IPlayerRepository playerRepo)
        {
            clubRepository = clubRepo;
            playerRepository = playerRepo;
        }
        public IViewComponentResult Invoke()
        {
            return View(new ClubsViewModel
            {
                ClubQty = clubRepository.Clubs.Count(),
                PlayerQty = playerRepository.Players.Count()
            });
        }
    }
}
