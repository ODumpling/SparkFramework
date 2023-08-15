﻿using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spark.Library.Extensions;
using Spark.Templates.Inertiajs.Application.Database;
using Spark.Templates.Inertiajs.Application.Services.Auth;
using Spark.Templates.Inertiajs.Application.ViewModels;

namespace Spark.Templates.Inertiajs.Application.Controllers
{
    public class PasswordController : Controller
    {
        private readonly UsersService _usersService;
        private readonly AuthService _authService;
        private readonly DatabaseContext _db;

        public PasswordController(UsersService usersService, DatabaseContext db, AuthService authService)
        {
            _usersService = usersService;
            _db = db;
            _authService = authService;
        }

        [Authorize]
        [HttpPost]
        [Route("password")]
        public async Task<IActionResult> Update(ProfilePasswordEditor request)
        {
            if (!ModelState.IsValid)
                return Inertia.Render("Profile/Edit", new { });

            var user = await _authService.GetAuthenticatedUser(User);
            var existingUser = await _usersService.FindUserAsync(user.Email, _usersService.GetSha256Hash(request.CurrentPassword));

            if (existingUser == null)
            {
                ModelState.AddModelError("CurrentPassword", "Current password was incorrect.");
                return Inertia.Render("Profile/Edit", new { });
            }

            existingUser.Password = _usersService.GetSha256Hash(request.NewPassword);

            _db.Users.Save(existingUser);
            return RedirectToAction("Edit", "Profile");
        }
    }
}
