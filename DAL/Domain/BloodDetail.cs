namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodDetail")]
    public partial class BloodDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloodDetail()
        {
            BloodSupplyDetails = new HashSet<BloodSupplyDetail>();
        }

        public int BloodDetailID { get; set; }

        public int BloodID { get; set; }

        public DateTime CollectionDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int? DonorID { get; set; }

        public virtual BloodStock BloodStock { get; set; }

        public virtual Donor Donor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodSupplyDetail> BloodSupplyDetails { get; set; }
    }
}
