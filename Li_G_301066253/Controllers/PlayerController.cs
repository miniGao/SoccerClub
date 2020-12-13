using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Li_G_301066253.Models;
using Li_G_301066253.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Li_G_301066253.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private IClubRepository clubRepository;
        private IPlayerRepository playerRepository;
        public PlayerController(IClubRepository repoClub, IPlayerRepository repoPlayer)
        {
            clubRepository = repoClub;
            playerRepository = repoPlayer;
        }
        [HttpGet]
        public IActionResult PlayerManagement(int clubId, string order = "name")
        {
            ManagePlayerModel playerModel = new ManagePlayerModel();
            playerModel.Clubs = clubRepository.Clubs.Where(c => c.ClubID != clubId).OrderBy(c => c.Name);
            playerModel.Club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == clubId);
            switch (order)
            {
                case "name":
                    playerModel.Players = playerRepository.Players.Where(p => p.ClubID == clubId).OrderBy(p => p.Name);
                    break;
                case "age":
                    playerModel.Players = playerRepository.Players.Where(p => p.ClubID == clubId).OrderBy(p => p.Age);
                    break;
                case "position":
                    playerModel.Players = playerRepository.Players.Where(p => p.ClubID == clubId).OrderBy(p => p.Position);
                    break;
                default:
                    playerModel.Players = playerRepository.Players.Where(p => p.ClubID == clubId).OrderBy(p => p.Name);
                    break;
            }
            if(playerModel.Club != null)
                return View(playerModel);
            TempData["warning"] = $"The club you were managing no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpPost]
        public RedirectToActionResult AddPlayer(ManagePlayerModel playerModel)
        {
            Club club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == playerModel.Player.ClubID);
            if (playerModel.Player.Name != null)
            {
                if (club != null)
                {
                    playerRepository.AddPlayer(playerModel.Player);
                    TempData["message"] = $"Player \"{playerModel.Player.Name}\" has been successfully added to \"{club.Name}\"";
                    return RedirectToAction(nameof(HomeController.ClubDetails), "Home", new { clubid = club.ClubID });
                }
                TempData["warning"] = $"Failed to add Player \"{playerModel.Player.Name}\" as the selected club no longer exists";
                return RedirectToAction(nameof(HomeController.Clubs), "Home");
            }
            if (club != null)
            {
                TempData["warning"] = $"Please complete the adding player form";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = club.ClubID });
            }
            TempData["warning"] = $"The club you were adding player to no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpPost]
        public RedirectToActionResult DeletePlayer(ManagePlayerModel playerModel)
        {
            if (playerModel.Player == null)
            {
                TempData["warning"] = "No player was selected to delete";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = playerModel.Club.ClubID });
            }
            int playerId = playerModel.Player.PlayerID;
            int clubId = playerModel.Club.ClubID;
            Player player = playerRepository.DeletePlayer(playerId);
            Club club;
            if (player != null)
            {
                club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID);
                TempData["warning"] = $"Player \"{player.Name}\" has been deleted from club \"{club.Name}\"";
                return RedirectToAction(nameof(HomeController.ClubDetails), "Home", new { clubid = club.ClubID });
            }
            club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == clubId);
            if (club != null)
            {
                TempData["warning"] = $"The player selected no longer exists";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = club.ClubID });
            }
            TempData["warning"] = $"The club you were managing no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpPost]
        public RedirectToActionResult ReassignPlayer(ManagePlayerModel playerModel)
        {
            if (playerModel.Player == null)
            {
                TempData["warning"] = "No player was selected";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = playerModel.Club.ClubID });
            }
            if (playerModel.NewClub == null)
            {
                TempData["warning"] = "No new club was selected";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = playerModel.Club.ClubID });
            }
            Club oldClub = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == playerModel.Club.ClubID);
            Club newClub = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == playerModel.NewClub.ClubID);
            if (newClub != null)
            {
                Player player = playerRepository.DeletePlayer(playerModel.Player.PlayerID);
                if (player != null)
                {
                    playerRepository.AddPlayer(new Player { Name = player.Name, Age = player.Age, Position = player.Position, ClubID = newClub.ClubID });
                    TempData["message"] = $"Player \"{player.Name}\" was transferred from \"{oldClub.Name}\" to \"{newClub.Name}\"";
                    return RedirectToAction(nameof(HomeController.ClubDetails), "Home", new { clubid = newClub.ClubID });
                }
                if (oldClub != null)
                {
                    TempData["warning"] = $"The selected player no longer exists";
                    return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = oldClub.ClubID });
                }
                TempData["warning"] = $"The club you were managing no longer exists";
                return RedirectToAction(nameof(HomeController.Clubs), "Home");
            }
            if (oldClub != null)
            {
                TempData["warning"] = $"The new club you selected no longer exists";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = oldClub.ClubID });
            }
            TempData["warning"] = $"Both the current club and the selected new club no longer exist";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpPost]
        public RedirectToActionResult UpdatePlayer(ManagePlayerModel playerModel)
        {
            if (playerModel.Player == null)
            {
                TempData["warning"] = "No player was selected";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = playerModel.Club.ClubID });
            }
            Player player = playerRepository.Players.FirstOrDefault(p => p.PlayerID == playerModel.Player.PlayerID);
            if (player != null)
            {
                return RedirectToAction(nameof(PlayerController.EditPlayer), new { playerid = player.PlayerID });
            }
            Club club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == playerModel.Club.ClubID);
            if (club != null)
            {
                TempData["warning"] = $"The selected player no longer exists";
                return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = club.ClubID });
            }
            TempData["warning"] = $"The club you were managing no longer exists";
            return RedirectToAction(nameof(HomeController.Clubs), "Home");
        }
        [HttpGet]
        public ViewResult EditPlayer(int playerId)
        {
            return View(playerRepository.Players.FirstOrDefault(p => p.PlayerID == playerId));
        }
        [HttpPost]
        public IActionResult EditPlayer(Player player)
        {
            Player dbPlayer;
            Club club;
            if (ModelState.IsValid)
            {
                dbPlayer = playerRepository.UpdatePlayer(player);
                if (dbPlayer != null)
                {
                    club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == dbPlayer.ClubID);
                    TempData["message"] = $"Changes of \"{dbPlayer.Name}\" in \"{club.Name}\" has been saved";
                    return RedirectToAction(nameof(HomeController.ClubDetails), "Home", new { clubid = club.ClubID });
                }
                club = clubRepository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID);
                if (club != null)
                {
                    TempData["warning"] = $"The player you were editing no longer exists";
                    return RedirectToAction(nameof(PlayerController.PlayerManagement), new { clubid = club.ClubID });
                }
                TempData["warning"] = $"The club that owns the edited player no longer exists";
                return RedirectToAction(nameof(HomeController.Clubs), "Home");
            }
            TempData["warning"] = $"Please complete this form";
            return View(player);
        }
    }
}