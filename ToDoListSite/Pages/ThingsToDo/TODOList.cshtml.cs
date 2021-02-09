using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using ToDoListSite.Data;
using ToDoListSite.Models;


namespace ToDoListSite
{
    public class TODOListModel : PageModel
    {
        private readonly ToDoListSite.Data.ToDoListSiteContext _context;
        [BindProperty]
        public ThingsToDo ThingToDo { get; set; }
        public TODOListModel(ToDoListSite.Data.ToDoListSiteContext context)
        {
            _context = context;
        }

        public IList<ThingsToDo> ThingsToDo { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id, string Delete, string Create, string Save, string IsDone)
        {
            if (!string.IsNullOrEmpty(Create))
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.ThingsToDo.Add(ThingToDo);


                await _context.SaveChangesAsync();
            }
            else if (!string.IsNullOrEmpty(Delete))
            {

                if (id == null)
                {
                    return NotFound();
                }

                ThingToDo = await _context.ThingsToDo.FindAsync(id);

                if (ThingToDo != null)
                {
                    _context.ThingsToDo.Remove(ThingToDo);
                    await _context.SaveChangesAsync();
                }
                
            }
            else if (!string.IsNullOrEmpty(Save))
            {
                var inputEditData = Request.Form["Content"];
                

                var things = _context.ThingsToDo.Find(id);
                _context.Entry(things).Property(u => u.Content).CurrentValue = inputEditData;
                await _context.SaveChangesAsync();
                
            }
            else
            {
                var things = _context.ThingsToDo.Find(id);
                if (_context.Entry(things).Property(u => u.IsDone).CurrentValue == "Yes")
                {
                    _context.Entry(things).Property(u => u.IsDone).CurrentValue = "No";
                }
                else
                {
                    _context.Entry(things).Property(u => u.IsDone).CurrentValue = "Yes";
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./TODOList");
        }
        private bool ThingsToDoExists(int id)
        {
            return _context.ThingsToDo.Any(e => e.ID == id);
        }
        



        

        public async Task OnGetAsync()
        {
            ThingsToDo = await _context.ThingsToDo.ToListAsync();
        }
        //[JSInvokable]
        public async Task<IActionResult> IsDoneMethod (int? id)
        {

            var things = _context.ThingsToDo.Find(id);
            if (_context.Entry(things).Property(u => u.IsDone).CurrentValue == "Yes")
            {
                _context.Entry(things).Property(u => u.IsDone).CurrentValue = "No";
            }
            else
            {
                _context.Entry(things).Property(u => u.IsDone).CurrentValue = "Yes";
            }
            
            await _context.SaveChangesAsync();


            return RedirectToPage("./TODOList");
    }

   
    }
}
