using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Li_G_301066253.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Li_G_301066253.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private IClubRepository repository;
        public CRUDController(IClubRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Update(int clubId)
        {
            Club club = repository.Clubs.FirstOrDefault(c => c.ClubID == clubId);
            if (club != null)
                return View(repository.Clubs.FirstOrDefault(c => c.ClubID == clubId));
            TempData["warning"] = "The club you were trying to reach no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpPost]
        public IActionResult Update(Club club)
        {
            Club dbClub;
            if (ModelState.IsValid)
            {
                dbClub = repository.EditClub(club);
                if (dbClub != null)
                {
                    TempData["message"] = $"Changes of \"{club.Name}\" have been saved";
                    return RedirectToAction(nameof(HomeController.ClubDetails), "Home", new { clubid = dbClub.ClubID });
                }
                TempData["warning"] = $"The club you were editing no longer exists";
                return RedirectToAction(nameof(HomeController.Clubs), "Home");
            }
            TempData["warning"] = $"Please complete this form";
            return View(club);
        }
        [HttpPost]
        public RedirectToActionResult Delete(int clubId)
        {
            Club club = repository.DeleteClub(clubId);
            if (club != null)
                TempData["warning"] = $"Club \"{club.Name}\" was deleted";
            else
                TempData["warning"] = $"The club you were trying to delete no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
    }
}