using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    // Bảng chi tiết yêu cầu cung cấp máu: chứa loại máu và số lượng 
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

        [ForeignKey("RequirementID")]
        public virtual BloodRequirement BloodRequirement { get; set; }
    }
}
