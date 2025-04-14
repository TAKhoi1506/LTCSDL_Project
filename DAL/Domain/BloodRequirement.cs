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
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string RU_ID { get; set; }

        //[Required]
        //[StringLength(10)]
        //public string BloodType { get; set; }

        //public double Amount { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime SupplyDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public virtual ReceivingUnit ReceivingUnit { get; set; }
        public virtual ICollection<BloodRequirementDetail> DetailList { get; set; }

    }
}
