using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BloodRequirementDetailBUS
    {
        BloodRequirementDetailDAL detailDAL = new BloodRequirementDetailDAL();

        public List<BloodRequirementDetailDTO> GetByRequirementID(int id)
        {
            return detailDAL.GetByRequirementID(id);
        }

        // Lấy tất cả chi tiết yêu cầu
        public List<BloodRequirementDetailDTO> GetAllDetails()
        {
            return detailDAL.GetAllDetails();
        }

        // Thêm chi tiết
        public void AddDetail(BloodRequirementDetailDTO detailDTO)
        {
            detailDAL.AddDetail(detailDTO);
        }

        // Xoá chi tiết
        public void DeleteDetail(int detailID)
        {
            detailDAL.DeleteDetail(detailID);
        }

        // Cập nhật chi tiết
        public void UpdateDetail(BloodRequirementDetailDTO detailDTO)
        {
            detailDAL.UpdateDetail(detailDTO);
        }

        //public List<BloodRequirementDetailDTO> SearchByBloodType(string bloodType)
        //{
        //    return detailDAL.SearchByBloodType(bloodType);
        //}


    }
}
