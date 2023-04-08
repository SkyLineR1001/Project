using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoScrap.Models;

namespace AutoScrap.Data
{
    public class AutoScrapContext : DbContext
    {
        public AutoScrapContext (DbContextOptions<AutoScrapContext> options)
            : base(options)
        {
        }

        public DbSet<AutoScrap.Models.Part> Part { get; set; } = default!;
    }
}
