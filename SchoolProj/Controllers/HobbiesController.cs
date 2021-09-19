using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProj.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolProj.Converters;

namespace SchoolProj.Controllers
{
    public class HobbiesController : Controller
    {
        private readonly MvcSchoolProjectContext _context;

        public HobbiesController(MvcSchoolProjectContext context)
        {
            _context = context;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index(string selectedItem, string searchString)
        {
            var hobbies = from m in _context.Hobbies select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                hobbies = hobbies.Where(h => h.Details.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(selectedItem) && selectedItem != "All")
            {
                var hobbyType = StringToEnum.Convert(typeof(HobbyType), selectedItem);
                hobbies = hobbies.Where(h => h.HobbyType == (HobbyType)hobbyType);
            }

            var hobbyVm = new HobbyViewModel
            {
                ItemsToSelect = new SelectList(EnumToString.Convert(typeof(HobbyType))),
                ListOfEntities = await hobbies.ToListAsync()
            };

            return View(hobbyVm);
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HobbyType,TimeSpend,Details,Id")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(hobby);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return View(hobby);
        }

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HobbyType,TimeSpend,Details,Id")] Hobby hobby)
        {
            if (id != hobby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbyExists(hobby.Id))
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
            return View(hobby);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobbies.Any(e => e.Id == id);
        }
    }
}
