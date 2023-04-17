using LabMiAu.Data;
using LabMiAu.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabMiAu.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //_db.Users.AddRange(new List<User>
            //{
            //    new User
            //    {
            //        Name="Tom",
            //        Age=17
            //    },
            //    new User
            //    {
            //        Name="Alice",
            //        Age=20
            //    }
            //});
            //_db.SaveChanges();//сохраняет изменения в бд
            return View(_db.Users.ToList());
            //IEnumerable<User> objList=_db.Users;
            //return View(objList);
        }
    }
}
