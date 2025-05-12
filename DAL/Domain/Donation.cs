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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donation()
        {
            HistoryDonations = new HashSet<HistoryDonation>();
        }

        public int DonationID { get; set; }

        public int DonorID { get; set; }

        public int EventID { get; set; }

        public virtual Donor Donor { get; set; }

        public virtual Event Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryDonation> HistoryDonations { get; set; }
    }
}
