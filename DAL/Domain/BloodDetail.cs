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
        [Key]
        [Column(Order = 0)]
        public int BloodDetailID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BloodID { get; set; }

        public DateTime CollectionDate { get; set; }

        public DateTime ExpiredDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int? DonorID { get; set; }

        public virtual BloodStock BloodStock { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
