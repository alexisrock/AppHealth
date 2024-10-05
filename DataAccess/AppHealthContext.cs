using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppHealthContext : DbContext
    {
        public AppHealthContext(DbContextOptions<AppHealthContext> options) : base(options) { }   
        public virtual DbSet<Settings>? Settings { get; set; }
        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<Symptoms>? Symptoms { get; set; }
        public virtual DbSet<Conditions>? Conditions { get; set; }
    }
}
