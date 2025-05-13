using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BloodRequirementBUS
    {
        //private readonly MyContext db = new MyContext();
        private BloodRequirementDAL brDAL = new BloodRequirementDAL();


        // Thêm yêu cầu máu mới
        public int AddRequirement(BloodRequirementDTO brDTO)
        {
            if (string.IsNullOrWhiteSpace(brDTO.RU_ID))
                throw new ArgumentException("Receiving Unit ID must not be null!");

            if (brDTO.SupplyDate < DateTime.Now.Date)
                throw new ArgumentException("The date of supply must not be less than the date of request!");

            return brDAL.AddRequirement(brDTO); // Trả về ID
        }

        // Lấy toàn bộ yêu cầu
        public List<BloodRequirementDTO> GetAllRequirements()
        {
            return brDAL.GetAllRequirements();
        }

        // Lấy yêu cầu theo Receiving Unit ID
        public List<BloodRequirementDTO> GetByUnitID(string ruId)
        {
            return brDAL.GetByUnitID(ruId);
        }

        // Xoá yêu cầu theo ID
        public void DeleteRequirement(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Requirement ID is invalid!");

            brDAL.DeleteRequirement(id);
        }

        // Cập nhật yêu cầu
        public void UpdateRequirement(BloodRequirementDTO brDTO)
        {
            if (brDTO.ID <= 0)
                throw new ArgumentException("Requirement ID is invalid!");

            if (string.IsNullOrWhiteSpace(brDTO.RU_ID))
                throw new ArgumentException("Receiving Unit ID must not be null!");

            if (brDTO.SupplyDate < DateTime.Now.Date)
                throw new ArgumentException("The date of supply must not be less than the date of request!");

            brDAL.UpdateRequirement(brDTO);
        }

        // Tim kiem yeu cau theo unit ID 
        public List<BloodRequirementDTO> SearchRequirementByID(string unitID)
        {
            return brDAL.SearchRequirementByID(unitID);
        }

        // Sort 
        public List<(BloodRequirementDTO Requirement, BloodRequirementDetailDTO Detail)> SortRequirements(string sortBy)
        {
            var results = brDAL.Sort(sortBy);

            return results.Select(x => (
                new BloodRequirementDTO
                {
                    ID = x.Requirement.ID,
                    RU_ID = x.Requirement.RU_ID,
                    RequestDate = x.Requirement.RequestDate,
                    SupplyDate = x.Requirement.SupplyDate,
                    Status = x.Requirement.Status
                },
                new BloodRequirementDetailDTO
                {
                    DetailID = x.Detail.DetailID,
                    RequirementID = x.Detail.RequirementID,
                    BloodType = x.Detail.BloodType,
                    Amount = x.Detail.Amount
                }
            )).ToList();
        }

        // cập nhật trạng thái requirement 
        public bool UpdateStatus(int requirementId, string newStatus)
        {
            if (string.IsNullOrEmpty(newStatus)) return false;

            BloodRequirementDAL dal = new BloodRequirementDAL();
            return dal.UpdateStatus(requirementId, newStatus);
        }
    }
}
