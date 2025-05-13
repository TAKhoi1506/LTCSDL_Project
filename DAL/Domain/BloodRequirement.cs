namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodRequirement")]
    public partial class BloodRequirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloodRequirement()
        {
            BloodRequirementDetails = new HashSet<BloodRequirementDetail>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string RU_ID { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime SupplyDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodRequirementDetail> BloodRequirementDetails { get; set; }

        public virtual ReceivingUnit ReceivingUnit { get; set; }
    }
}
