using DAL.Domain;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class BloodRequirementBUS
    {
        private MyContext db = new MyContext();

        public bool SendBloodRequirement(BloodRequirementDTO requirementDTO)
        {
            try
            {
                // Bước 1: Map từ DTO sang Entity
                var requirementEntity = new BloodRequirement
                {
                    RU_ID = requirementDTO.RU_ID,
                    SupplyDate = requirementDTO.SupplyDate,
                    RequestDate = requirementDTO.RequestDate,
                    Status = requirementDTO.Status,
                    DetailList = new List<BloodRequirementDetail>()
                };

                foreach (var detail in requirementDTO.DetailList)
                {
                    requirementEntity.DetailList.Add(new BloodRequirementDetail
                    {
                        BloodType = detail.BloodType,
                        Amount = detail.Amount
                    });
                }

                // Bước 2: Thêm vào context và lưu thay đổi
                db.BloodRequirements.Add(requirementEntity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public List<BloodRequirementDTO> GetAllRequirementsByRU(string ruId)
        {
            var list = db.BloodRequirements
                         .Where(r => r.RU_ID == ruId)
                         .Select(r => new BloodRequirementDTO
                         {
                             ID = r.ID,
                             RU_ID = r.RU_ID,
                             RequestDate = r.RequestDate,
                             SupplyDate = r.SupplyDate,
                             Status = r.Status,
                             DetailList = r.DetailList.Select(d => new BloodRequirementDetailDTO
                             {
                                 BloodType = d.BloodType,
                                 Amount = d.Amount
                             }).ToList()
                         }).ToList();

            return list;
        }
    }
}

