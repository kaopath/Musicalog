using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
    }
}
