namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodStock")]
    public partial class BloodStock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloodStock()
        {
            BloodDetails = new HashSet<BloodDetail>();
        }

        [Key]
        public int BloodID { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodType { get; set; }

        public double Amount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodDetail> BloodDetails { get; set; }
    }
}
