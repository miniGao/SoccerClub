using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Li_G_301066253.Models;
using Li_G_301066253.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Li_G_301066253.Controllers
{
    public class HomeController : Controller
    {
        private IClubRepository repository;
        public HomeController(IClubRepository repo)
        {
            repository = repo;
        }
        public ViewResult Home()
        {
            return View();
        }
        public ViewResult Clubs()
        {
            return View(repository.Clubs);
        }
        public ViewResult ClubDetails(int clubId, string filter)
        {
            Club club = repository.Clubs.FirstOrDefault(c => c.ClubID == clubId);
            if (club == null)
            {
                TempData["warning"] = $"The club you were trying to visit no longer exist";
                return View(nameof(HomeController.Clubs), repository.Clubs);
            }
            if (club.Players.Count == 0)
            {
                TempData["warning"] = $"{club.Name} has no player, please add player in player management";
            }
            else
            {
                switch (filter)
                {
                    case "forward":
                        club.Players = club.Players.Where(p => p.Position == "Forward").OrderBy(p => p.Name).ToList();
                        break;
                    case "midfielder":
                        club.Players = club.Players.Where(p => p.Position == "Midfielder").OrderBy(p => p.Name).ToList();
                        break;
                    case "defender":
                        club.Players = club.Players.Where(p => p.Position == "Defender").OrderBy(p => p.Name).ToList();
                        break;
                    case "goalkeeper":
                        club.Players = club.Players.Where(p => p.Position == "Goalkeeper").OrderBy(p => p.Name).ToList();
                        break;
                    default:
                        club.Players = club.Players.OrderBy(p => p.Name).ToList();
                        break;
                }
            }
            return View(club);
        }
        [HttpGet]
        [Authorize]
        public ViewResult AddClub()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ViewResult AddClub(Club club)
        {
            if (ModelState.IsValid)
            {
                club.Players = new List<Player>();
                repository.AddClub(club);
                TempData["message"] = $"New club \"{club.Name}\" has been created";
                return View("Clubs", repository.Clubs);
            }
            TempData["warning"] = $"Please complete this form";
            return View();
        }
    }
}