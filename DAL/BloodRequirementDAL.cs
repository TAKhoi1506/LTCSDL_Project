using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

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
        public List<BloodRequirementDTO> GetByUnitID(string ruId)
        {
            return db.BloodRequirements
             .Where(r => r.RU_ID == ruId)
             .Select(r => new BloodRequirementDTO
             {
                 ID = r.ID,
                 RU_ID = r.RU_ID,
                 RequestDate = r.RequestDate,
                 SupplyDate = r.SupplyDate,
                 Status = r.Status
             })
             .ToList();
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


            foreach (var detailDTO in brDTO.DetailList)
            {
                db.BloodRequirementDetails.Add(new BloodRequirementDetail
                {
                    RequirementID =entity.ID,
                    BloodType = detailDTO.BloodType,
                    Amount = detailDTO.Amount
                });
            }

            db.SaveChanges();
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

        public bool UpdateStatus(int requirementId, string newStatus)
        {
            try
            {
                var requirement = db.BloodRequirements.FirstOrDefault(r => r.ID == requirementId);
                if (requirement == null) return false;

                requirement.Status = newStatus;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
