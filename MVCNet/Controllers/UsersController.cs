using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCNet.Services;
using MVCNet.ViewModels;
using System.Xml.Linq;

namespace MVCNet.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService service;
        private readonly IProfileService profileService;

        public UsersController(IUserService service, IProfileService profileService) {
            this.service = service;
            this.profileService = profileService;
        }

        public async Task<ActionResult> Index() {

            var users = await service.GetAllUsers();

            return View(users);
        }

        public async Task<ActionResult> CreateUser()
        {
            var profiles = await profileService.GetAll();
            ViewBag.Profiles = new SelectList(profiles, "IdProfile", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.CreateUser(model.Name, model.ProfileId);
                TempData["Message"] = "Usuario Creado";
                return RedirectToAction(nameof(Index));
            }

            var profiles = await profileService.GetAll();
            ViewData["Profiles"] = new SelectList(profiles, "Id", "Name",model.ProfileId);

            return View(model);
        }

        public async Task<ActionResult> EditUser(int id)
        {
            var user = await service.GetUserById(id);

            UpdateUserViewModel vm = new UpdateUserViewModel()
            {
                Id = id,
                Name = user.Name,
                ProfileId = user.ProfileId.Value
            };

            var profiles = await profileService.GetAll();
            ViewBag.Profiles = new SelectList(profiles, "IdProfile", "Name");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateUser(model.Id, model.Name, model.ProfileId);
                TempData["Message"] = "Usuario Actualizado";
                return RedirectToAction(nameof(Index));
            }

            var profiles = await profileService.GetAll();
            ViewData["Profiles"] = new SelectList(profiles, "Id", "Name", model.ProfileId);

            return View(model);
        }
    }
}
