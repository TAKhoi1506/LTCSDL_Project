namespace DAL.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
        : base(@"data source=ZY-COM\\MYSERVER;initial catalog=BloodBank1;integrated security=True")
        {
        }

        public virtual DbSet<BloodDetail> BloodDetails { get; set; }
        public virtual DbSet<BloodRequirement> BloodRequirements { get; set; }
        public virtual DbSet<BloodRequirementDetail> BloodRequirementDetails { get; set; }
        public virtual DbSet<BloodStock> BloodStocks { get; set; }
        public virtual DbSet<BloodSupplyDetail> BloodSupplyDetails { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<HistoryDonation> HistoryDonations { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<ReceivingUnit> ReceivingUnits { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodDetail>()
                .HasMany(e => e.BloodSupplyDetails)
                .WithRequired(e => e.BloodDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BloodRequirement>()
                .Property(e => e.RU_ID)
                .IsFixedLength();

            modelBuilder.Entity<BloodRequirement>()
                .HasMany(e => e.BloodRequirementDetails)
                .WithRequired(e => e.BloodRequirement)
                .HasForeignKey(e => e.RequirementID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BloodRequirementDetail>()
                .HasMany(e => e.BloodSupplyDetails)
                .WithRequired(e => e.BloodRequirementDetail)
                .HasForeignKey(e => e.RequirementDetailID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BloodStock>()
                .HasMany(e => e.BloodDetails)
                .WithRequired(e => e.BloodStock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.Donations)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .HasMany(e => e.HistoryDonations)
                .WithRequired(e => e.Donor)
                .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Event>()
        //        .HasMany(e => e.Donations)
        //        .WithRequired(e => e.Event)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ReceivingUnit>()
        //        .Property(e => e.RU_ID)
        //        .IsFixedLength();

            modelBuilder.Entity<ReceivingUnit>()
                .HasMany(e => e.BloodRequirements)
                .WithRequired(e => e.ReceivingUnit)
                .WillCascadeOnDelete(false);
        }
    }
}
