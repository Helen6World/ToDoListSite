using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListSite.Models;

namespace ToDoListSite.Data
{
    public class ToDoListSiteContext : DbContext
    {
        public ToDoListSiteContext (DbContextOptions<ToDoListSiteContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoListSite.Models.ThingsToDo> ThingsToDo { get; set; }
    }
}
