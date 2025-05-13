namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodRequirementDetail")]
    public partial class BloodRequirementDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloodRequirementDetail()
        {
            BloodSupplyDetails = new HashSet<BloodSupplyDetail>();
        }

        [Key]
        public int DetailID { get; set; }

        public int RequirementID { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodType { get; set; }

        public double Amount { get; set; }

        public virtual BloodRequirement BloodRequirement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodSupplyDetail> BloodSupplyDetails { get; set; }
    }
}
