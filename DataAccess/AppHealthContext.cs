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
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonStateProvince> PersonStateProvince { get; set; }

    }
}
