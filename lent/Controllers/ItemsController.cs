using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lent.Models;

namespace lent.Controllers
{
    public class ItemsController : Controller
    {
        private readonly lentContext _context;


        //eigene Methoden
        public async Task<IActionResult> MyItems(int ID)
        {
            var lentContext = _context.Item.Include(i => i.Owner);
            List<lent.Models.Item> OwnerItems = _context.Item.Where(i => i.Owner.ID == ID).ToList();
            return View("Index", OwnerItems);
        }

        public async Task<IActionResult> MyBorrowedItems(int ID)
        {
            var lentContext = _context.Item.Include(i => i.Owner);
            List<lent.Models.Item> BorrowedItems = _context.Item.Where(i => i.Borrower.ID == ID).ToList();
            return View("Index", BorrowedItems);
        }
        
        

        //Ende eigene Methoden


        public ItemsController(lentContext context)
        {
            _context = context;
        }

        // GET: Items1
        public async Task<IActionResult> Index(string id)
        {
            var lentContext = _context.Item.Include(i => i.Borrower).Include(i => i.Owner);
        //Suche
            var item = from i in _context.Item
                       select i ;

            if (!String.IsNullOrEmpty(id))
            {
                item = item.Where(s => s.Name.Contains(id));
            }
            return View(await item.ToListAsync());
        }

        // GET: Items1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Borrower)
                .Include(i => i.Owner)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items1/Create
        public IActionResult Create()
        {
            ViewData["OwnerForeignkey"] = new SelectList(_context.User, "ID", "Login");
            List<User> ulist = _context.User.ToList();
            ulist.Add(CreateDummy());

            ViewData["CategoryForeignkey"] = new SelectList(_context.Category, "ID", "Name");

            ViewData["BorrowerForeignkey"] = new SelectList(ulist, "ID", "Login", CreateDummy().ID);
            return View();
        }

        // POST: Items1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategorie,CategoryForeignkey,Name,OwnerForeignkey,BorrowerForeignkey,Discription,Status")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.Status == false)
                {
                    item.BorrowerForeignkey = null;

                }
                else
                    item.BorrowerForeignkey = item.OwnerForeignkey;
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerForeignkey"] = new SelectList(_context.User, "ID", "Login", item.OwnerForeignkey);
            item.BorrowerForeignkey = CreateDummy().ID;
            _context.User.Add(CreateDummy());
            
            ViewData["BorrowerForeignkey"] = new SelectList(_context.User, "ID", "Login", item.BorrowerForeignkey);
            ViewData["CategoryForeignkey"] = new SelectList(_context.Category, "ID", "Name", item.CategoryForeignkey);

            return View(item);
        }

        //##########  EIGENE METHODEN ################
        private User CreateDummy()
        {
            User dummy = new User();
            dummy.Login = "DUMMY";
            dummy.Lastname = "NICHT VERLIEHEN";
            dummy.Surname = "test";
            dummy.Password = "dummypassword";
            dummy.EMail = "dummy@dummy.de";
            dummy.ID = -1; //da in DB keine negativen int existieren

            return dummy;
        }

        // GET: Items1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["BorrowerForeignkey"] = new SelectList(_context.User, "ID", "EMail", item.BorrowerForeignkey);
            ViewData["OwnerForeignkey"] = new SelectList(_context.User, "ID", "EMail", item.OwnerForeignkey);
            return View(item);
        }

        // POST: Items1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Name,OwnerForeignkey,BorrowerForeignkey,Discription,Status")] Item item)
        {
            if (id != item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ID))
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
            ViewData["BorrowerForeignkey"] = new SelectList(_context.User, "ID", "EMail", item.BorrowerForeignkey);
            ViewData["OwnerForeignkey"] = new SelectList(_context.User, "ID", "EMail", item.OwnerForeignkey);
            return View(item);
        }

        // GET: Items1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Borrower)
                .Include(i => i.Owner)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ID == id);
        }
    }
}
