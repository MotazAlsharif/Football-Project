using FootballGame.Date;
using FootballGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FootballGame.Controllers
{
    public class UserController : Controller
    {

        private SystemDbContext _context;

        public UserController(SystemDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            bool empty=checkEmpty(user);
            bool duplicat = checkUsername(user.Username);

            if (empty)
            {
                if (duplicat)
                {
                    _context.user.Add(user);
                    _context.SaveChanges();

                    TempData["Msg"] = "the data was saved";
                    return View();
                }
                else
                {
                    TempData["Msg"] = "Please Change the username";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input ";
                return View();
            }
            
            
            
        }


        public bool checkUsername(string username)
        {
  

            User user = _context.user.Where(u => u.Username.Equals(username)).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEmpty(User user)
        {
            if (String.IsNullOrEmpty(user.Username)) return false;
            else if (String.IsNullOrEmpty(user.password)) return false;
            else if (String.IsNullOrEmpty(user.name)) return false;
            else return true;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                string username=userlogin.username;
                string password = userlogin.password;

               User user=  _context.user.Where(
                    u => u.Username.Equals(username) &&
                    u.password.Equals(password)
                    ).FirstOrDefault();

                Admin admin = _context.admin.Where(
                    a=>a.username.Equals(username)
                    &&
                    a.password.Equals(password)
                    ).FirstOrDefault();




                if (user != null)
                {
                    HttpContext.Session.SetInt32("userid", user.ID);
                        
                    return RedirectToAction("TeamList");

                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.ID);

                    return RedirectToAction("Index","Teams");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else {
            
            }
            return View();
        }


        [HttpGet]
        public IActionResult TeamList()
        {

            int userid = (int)HttpContext.Session.GetInt32("userid");

            List<int> lst = _context.teams_Users.Where(
                t => t.user.ID == userid
                ).Select(s => s.team.ID).ToList();

            List<Teams> lst_teams = _context.teams.ToList();

            List<Teams> flst = new List<Teams>();
            for(int i = 0; i < lst_teams.Count(); i++)
            {
                if (!(lst.Contains(lst_teams[i].ID))){
                    flst.Add(lst_teams[i]);
                }
            }
            

            return View(flst);
        }

        public IActionResult AddFav(int id)
        {
            int teamid = id;
            int userid = (int)HttpContext.Session.GetInt32("userid");

            Teams_Users teams_User = new Teams_Users();

            teams_User.user = _context.user.Find(userid);
            teams_User.team = _context.teams.Find(teamid);

            _context.teams_Users.Add(teams_User);
            _context.SaveChanges();

            return RedirectToAction("FavList");
            
        }
        public IActionResult FavList()
        {
            int userid = (int)HttpContext.Session.GetInt32("userid");

            List<int> lst = _context.teams_Users.Where(
                t => t.user.ID == userid
                ).Select(s => s.team.ID).ToList();

            List<Teams> lst_teams = _context.teams.Where(
                t => lst.Contains(t.ID)
                ).ToList();
            
            return View(lst_teams);
        }
        public ActionResult Delete(int id)
        {
            int tid = _context.teams_Users.Where(
                t => t.team.ID == id
                ).Select(s => s.ID).FirstOrDefault(); 

            Teams_Users t = _context.teams_Users.Find(tid);
            _context.teams_Users.Remove(t);
            _context.SaveChanges();

            return RedirectToAction("FavList");
        }
    }
}
