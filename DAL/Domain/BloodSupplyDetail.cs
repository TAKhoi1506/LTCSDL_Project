namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodSupplyDetail")]
    public partial class BloodSupplyDetail
    {
        [Key]
        public int SupplyID { get; set; }

        public int RequirementDetailID { get; set; }

        public int BloodDetailID { get; set; }

        public double Amount { get; set; }

        public virtual BloodDetail BloodDetail { get; set; }

        public virtual BloodRequirementDetail BloodRequirementDetail { get; set; }
    }
}
