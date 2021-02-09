using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListSite.Models
{
    public class ThingsToDo
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string IsDone { get; set; }
    }
}
