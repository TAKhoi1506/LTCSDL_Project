namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HistoryDonation")]
    public partial class HistoryDonation
    {
        [Key]
        public int HisDonaID { get; set; }

        public int DonorID { get; set; }

        public int? DonationID { get; set; }

        public int? EventID { get; set; }

        public DateTime DonationDate { get; set; }

        public double Weight { get; set; }

        [StringLength(20)]
        public string BloodPressure { get; set; }

        public double? Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string HealthStatus { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public virtual Donation Donation { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Event { get; set; }
    }
}
