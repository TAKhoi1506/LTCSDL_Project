namespace DAL.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
        : base(@"data source=LAPTOP-3RVB0QLD;initial catalog=BloodBank;integrated security=True")
        {
        }

        public virtual DbSet<BloodDetail> BloodDetails { get; set; }
        public virtual DbSet<BloodRequirement> BloodRequirements { get; set; }

        public virtual DbSet<BloodRequirementDetail> BloodRequirementDetails { get; set; }  
        public virtual DbSet<BloodStock> BloodStocks { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ReceivingUnit> ReceivingUnits { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<HistoryDonation> HistoryDonations { get; set; }    


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BloodRequirement>()
        //        .Property(e => e.RU_ID)
        //        .IsFixedLength();

        //    modelBuilder.Entity<BloodStock>()
        //        .HasMany(e => e.BloodDetails)
        //        .WithRequired(e => e.BloodStock)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Donor>()
        //        .Property(e => e.UserName)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Donor>()
        //        .Property(e => e.Password)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Donor>()
        //        .Property(e => e.PhoneNumber)
        //        .IsFixedLength();

        //    modelBuilder.Entity<Donor>()
        //        .HasMany(e => e.Donations)
        //        .WithRequired(e => e.Donor)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Event>()
        //        .HasMany(e => e.Donations)
        //        .WithRequired(e => e.Event)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ReceivingUnit>()
        //        .Property(e => e.RU_ID)
        //        .IsFixedLength();

        //    modelBuilder.Entity<ReceivingUnit>()
        //        .Property(e => e.Password)
        //        .IsFixedLength();

        //    modelBuilder.Entity<ReceivingUnit>()
        //        .HasMany(e => e.BloodRequirements)
        //        .WithRequired(e => e.ReceivingUnit)
        //        .WillCascadeOnDelete(false);


           
        //}
    }
}
