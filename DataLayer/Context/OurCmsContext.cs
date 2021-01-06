using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OurCmsContext:DbContext
    {
        public virtual DbSet<PageGroup> PageGroups { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PageComment> PageComments { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<DataRezervcs> DataRezervcs { get; set; }
        public virtual DbSet<Numbering> Numberings { get; set; }

    }
}
