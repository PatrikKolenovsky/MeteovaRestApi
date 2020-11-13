using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class MeteovaContext : DbContext
    {

        public MeteovaContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Envidata> Envidata { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Maker> Maker { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Moduletype> Moduletype { get; set; }
        public virtual DbSet<Valint> Valint { get; set; }
        public virtual DbSet<Valreal> Valreal { get; set; }
        public virtual DbSet<Valstring> Valstring { get; set; }
        public virtual DbSet<Vardef> Vardef { get; set; }
        public virtual DbSet<Variable> Variable { get; set; }
        public virtual DbSet<Varname> Varname { get; set; }
        public virtual DbSet<Vartype> Vartype { get; set; }

    }
}
