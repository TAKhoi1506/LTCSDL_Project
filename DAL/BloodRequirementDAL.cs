using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Domain;
using DTO;
using System.Data.Entity;

namespace DAL
{
    public class BloodRequirementDAL
    {
        private readonly MyContext db = new MyContext();

        // Lấy tất cả yêu cầu
        public List<BloodRequirementDTO> GetAllRequirements()
        {
            return db.BloodRequirements
                     .Select(br => new BloodRequirementDTO
                     {
                         ID = br.ID,
                         RU_ID = br.RU_ID,
                         RequestDate = br.RequestDate,
                         SupplyDate = br.SupplyDate,
                         Status = br.Status
                     })
                     .ToList();
        }

        // Lấy yêu cầu theo mã đơn vị nhận
        public BloodRequirementDTO GetByUnitID(string unitID)
        {
            var entity = db.BloodRequirements
                           .FirstOrDefault(br => br.RU_ID == unitID);

            if (entity == null) return null;

            return new BloodRequirementDTO
            {
                ID = entity.ID,
                RU_ID = entity.RU_ID,
                RequestDate = entity.RequestDate,
                SupplyDate = entity.SupplyDate,
                Status = entity.Status
            };
        }

        // Thêm yêu cầu mới
        public int AddRequirement(BloodRequirementDTO brDTO)
        {
            var entity = new BloodRequirement
            {
                RU_ID = brDTO.RU_ID,
                RequestDate = DateTime.Now,
                SupplyDate = brDTO.SupplyDate,
                Status = string.IsNullOrEmpty(brDTO.Status) ? "Pending" : brDTO.Status
            };

            db.BloodRequirements.Add(entity);
            db.SaveChanges();


            // Cập nhật ID vừa thêm vào DTO nếu cần
            return entity.ID;
        }

        // Xoá yêu cầu theo ID
        public void DeleteRequirement(int id)
        {
            var entity = db.BloodRequirements.Find(id);
            if (entity != null)
            {
                db.BloodRequirements.Remove(entity);
                db.SaveChanges();
            }
        }

        // Cập nhật yêu cầu
        public void UpdateRequirement(BloodRequirementDTO brDTO)
        {
            var entity = db.BloodRequirements.Find(brDTO.ID);
            if (entity != null)
            {
                entity.RU_ID = brDTO.RU_ID;
                entity.SupplyDate = brDTO.SupplyDate;
                entity.Status = brDTO.Status;

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Search 
        public List<BloodRequirementDTO> SearchRequirementByID(string unitID)
        {
            var requirements = db.BloodRequirements
                                 .Where(r => r.RU_ID == unitID)
                                 .Select(r => new BloodRequirementDTO
                                 {
                                     ID = r.ID,
                                     RU_ID = r.RU_ID,
                                     RequestDate = r.RequestDate,
                                     SupplyDate = r.SupplyDate,
                                     Status = r.Status
                                 })
                                 .ToList();

            return requirements;
        }


        // Sắp xếp 
        public List<(BloodRequirement Requirement, BloodRequirementDetail Detail)> Sort(string sortBy)
        {
            var query = from requirement in db.BloodRequirements
                        join detail in db.BloodRequirementDetails
                        on requirement.ID equals detail.RequirementID
                        select new { requirement, detail };

            switch (sortBy)
            {
                case "Unit ID":
                    query = query.OrderBy(x => x.requirement.RU_ID);
                    break;
                case "Request date":
                    query = query.OrderBy(x => x.requirement.RequestDate);
                    break;
                case "Supply date":
                    query = query.OrderBy(x => x.requirement.SupplyDate);
                    break;
                case "Blood type":
                    query = query.OrderBy(x => x.detail.BloodType);
                    break;
                case "Amount":
                    query = query.OrderBy(x => x.detail.Amount);
                    break;
                case "Status":
                    query = query.OrderBy(x => x.requirement.Status);
                    break;
                default:
                    break;
            }

            return query.ToList()
                        .Select(x => (x.requirement, x.detail))
                        .ToList();
        }
    }

}
