using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PIPOC_WMDB.IRepository;
using PIPOC_WMDB.Models;

namespace PIPOC_WMDB.Controllers
{
    public class UsersController : Controller
    {
        private IUserRespository _userRepo = null;
        public UsersController(IUserRespository userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser()
        {
            var users = _userRepo.Gets();
            return Json(users);
        }

        public JsonResult SaveUser(Users user)
        {
            var u = _userRepo.Save(user);
            return Json(u);
        }

        public JsonResult DeleteUser(string userId)
        {
            var message = _userRepo.Delete(userId);
            return Json(message);
        }

    }
}

