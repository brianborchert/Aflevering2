using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smileys.Models;

namespace Smileys.Data
{
    public class SmileysContext : DbContext
    {
        public SmileysContext (DbContextOptions<SmileysContext> options)
            : base(options)
        {
        }

        public DbSet<Smileys.Models.Company> Company { get; set; } = default!;
    }
}
