namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donation")]
    public partial class Donation
    {
        public int DonationID { get; set; }

        public int DonorID { get; set; }

        public int EventID { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Event { get; set; }
    }
}
