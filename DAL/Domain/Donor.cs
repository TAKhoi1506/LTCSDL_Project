namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donor")]
    public partial class Donor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donor()
        {
            BloodDetails = new HashSet<BloodDetail>();
            Donations = new HashSet<Donation>();
        }

        public int DonorID { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string UserName { get; set; }

        //[Required]
        //[StringLength(30)]
        //public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(3)]
        public string BloodType { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastDonationDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodDetail> BloodDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
