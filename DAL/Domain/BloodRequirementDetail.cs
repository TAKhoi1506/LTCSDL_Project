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
        [Key]
        public int DetailID { get; set; }

        public int RequirementID { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodType { get; set; }

        public double Amount { get; set; }

        public virtual BloodRequirement BloodRequirement { get; set; }
    }
}
