using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballGame.Date;
using FootballGame.Models;

namespace FootballGame.Controllers
{
    public class PlayersController : Controller
    {
        private readonly SystemDbContext _context;

        public PlayersController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            return _context.players != null ?
                        View(await _context.players.ToListAsync()) :
                        Problem("Entity set 'SystemDbContext.players'  is null.");
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var players = await _context.players
                .FirstOrDefaultAsync(m => m.ID == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewBag.Teams = _context.teams.ToList();
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {

            string name = form["name"];
            string skilllevel = form["skilllevel"];
            int teamID = int.Parse(form["TeamID"]);

            Players player = new Players();
            player.name = name;
            player.skilllevel = skilllevel;
            player.teams = _context.teams.Find(teamID);

            _context.players.Add(player);
            _context.SaveChanges();

            return RedirectToAction("Index");




        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var players = await _context.players.FindAsync(id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,skilllevel")] Players players)
        {
            if (id != players.ID)
            {
                return NotFound();
            }


            _context.Update(players);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));


        }

        // GET: Players/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var players = await _context.players
                .FirstOrDefaultAsync(m => m.ID == id);
            if (players == null)
            {
                return NotFound();
            }

            return View(players);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.players == null)
            {
                return Problem("Entity set 'SystemDbContext.players'  is null.");
            }
            var players = await _context.players.FindAsync(id);
            if (players != null)
            {
                _context.players.Remove(players);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayersExists(int id)
        {
            return (_context.players?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
