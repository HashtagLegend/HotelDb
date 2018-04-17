namespace HotelDbWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewContext : DbContext
    {
        public ViewContext()
            : base("name=ViewContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GuestList> GuestList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestList>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<GuestList>()
                .Property(e => e.GuestName)
                .IsUnicode(false);
        }
    }
}
