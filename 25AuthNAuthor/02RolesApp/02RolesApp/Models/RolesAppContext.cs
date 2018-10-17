using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _02RolesApp.Models
{
    public class RolesAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public RolesAppContext(DbContextOptions<RolesAppContext> options)
            : base(options)
        {
        }
    }
}
