using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using H5ServersideAni.Areas.ToDoList.Models;
using H5ServersideAni.Areas.ToDoList.Code;
using Microsoft.AspNetCore.DataProtection;

namespace H5ServersideAni.Areas.ToDoList.Controllers
{
    [Area("ToDoList")]
    [Route("ToDoList/[controller]/[action]")]
    public class InfoesController : Controller
    {
        private readonly ToDoServerContext _context;

        private readonly IDataProtector _dataProtector;

        private readonly Cryptexample _cryptexample;

        public InfoesController(ToDoServerContext context, Cryptexample cryptexample, IDataProtectionProvider dataProtector )
        {
            _cryptexample = cryptexample;
            _context = context;
            _dataProtector =  dataProtector.CreateProtector("H5ServerSideAni.HomeController.SecretKey");

        }

        // GET: ToDoList/Infoes
        public async Task<IActionResult> Index()
        {
            var userIdentityname = User.Identity.Name;

            var rows = await _context.Infos.Where(s => s.UserName == userIdentityname).ToListAsync();
            bool matchFound = rows.Count > 0;

            if (matchFound)
			{
                foreach(ToDoList.Models.Info row in rows)
				{
                    string ecryptedText = row.Beskrivelse;
                    row.Beskrivelse = _cryptexample.Decrypt(ecryptedText, _dataProtector);
                }
                return View(rows);
			}
            else
			{
                return View(new List<ToDoList.Models.Info>());
			}

            return View(await _context.Infos.ToListAsync());
        }

        // GET: ToDoList/Infoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: ToDoList/Infoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Infoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Titel,Beskrivelse")] H5ServersideAni.Areas.ToDoList.Models.Info info)
        {
            if (ModelState.IsValid)
            {
                string beskrivelse = info.Beskrivelse;
                info.Beskrivelse = _cryptexample.Encrypt(beskrivelse, _dataProtector);

                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(info);
        }

        // GET: ToDoList/Infoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: ToDoList/Infoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Titel,Beskrivelse")] Info info)
        {
            if (id != info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(info);
        }

        // GET: ToDoList/Infoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: ToDoList/Infoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Infos.FindAsync(id);
            _context.Infos.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Infos.Any(e => e.Id == id);
        }
    }
}
