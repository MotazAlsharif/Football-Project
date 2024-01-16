using FootballGame.Date;
using FootballGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballGame.Controllers
{
    public class TeamsController : Controller
    {

        private SystemDbContext _context;

        public TeamsController(SystemDbContext context)
        {
            this._context = context;
        }

        // GET: TeamsContoller
        public ActionResult Index()
        {
            return View(_context.teams.ToList());
        }

        // GET: TeamsContoller/Details/5
        public ActionResult Details(int id)
        {
            Teams team = _context.teams.Find(id);

            return View(team);
        }

        // GET: TeamsContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamsContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teams teams)
        {
            try
            {

                int adminid = (int)HttpContext.Session.GetInt32("adminID");

                Admin admin = _context.admin.Where(
                  a => a.ID== adminid
                  ).FirstOrDefault();

                teams.Admin = admin;

                _context.teams.Add(teams);
                _context.SaveChanges();
            
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsContoller/Edit/5
        public ActionResult Edit(int id)
        {
            Teams team = _context.teams.Find(id);

            return View(team);
        }

        // POST: TeamsContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teams teams)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.teams.Update(teams);

                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamsContoller/Delete/5
        public ActionResult Delete(int id)
        {
            Teams team = _context.teams.Find(id);
            _context.teams.Remove(team);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        // POST: TeamsContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Teams team)
        {
            try
            {
                _context.teams.Remove(team);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
