namespace MarkSecuritiesDataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MarkSecuritiesModelEx : DbContext
    {
        public MarkSecuritiesModelEx()
            : base("name=MarkSecuritiesModelEx")
        {
        }

        public virtual DbSet<vIsAAA> vIsAAAs { get; set; }
        public virtual DbSet<vIsAAA1> vIsAAA1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vIsAAA>()
                .Property(e => e.SecurityCode)
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA>()
                .Property(e => e.SecurityName)
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA>()
                .Property(e => e.SecurityType)
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA>()
                .Property(e => e.IBLCProfile)
                .HasPrecision(3, 0);

            modelBuilder.Entity<vIsAAA>()
                .Property(e => e.ISIN)
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA1>()
                .Property(e => e.CUSIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA1>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vIsAAA1>()
                .Property(e => e.StructuredProductIndicator)
                .IsUnicode(false);
        }
    }
}
