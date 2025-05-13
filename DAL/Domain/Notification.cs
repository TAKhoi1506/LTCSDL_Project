namespace DAL.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [Key]
        public int NotifiID { get; set; }

        [Required]
        [StringLength(10)]
        public string ObjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Message { get; set; }

        public DateTime CreateAt { get; set; }

        public bool IsRead { get; set; }
    }
}
