using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoItemApi.Models
{
    public class ToDoItemContext : DbContext
    {
        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}
