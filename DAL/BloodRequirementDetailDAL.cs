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
    public class BloodRequirementDetailDAL
    {
        private readonly MyContext db = new MyContext();

        // Lấy toàn bộ chi tiết yêu cầu máu
        public List<BloodRequirementDetailDTO> GetAllDetails()
        {
            return db.BloodRequirementDetails
                     .Select(d => new BloodRequirementDetailDTO
                     {
                         DetailID = d.DetailID,
                         RequirementID = d.RequirementID,
                         BloodType = d.BloodType,
                         Amount = d.Amount
                     })
                     .ToList();
        }

        // Lấy danh sách chi tiết theo ID yêu cầu
        public List<BloodRequirementDetailDTO> GetByRequirementID(int requirementID)
        {
            return db.BloodRequirementDetails
                     .Where(d => d.RequirementID == requirementID)
                     .Select(d => new BloodRequirementDetailDTO
                     {
                         DetailID = d.DetailID,
                         RequirementID = d.RequirementID,
                         BloodType = d.BloodType,
                         Amount = d.Amount
                     })
                     .ToList();
        }

        // Thêm chi tiết mới
        public void AddDetail(BloodRequirementDetailDTO detailDTO)
        {
            var entity = new BloodRequirementDetail
            {
                RequirementID = detailDTO.RequirementID,
                BloodType = detailDTO.BloodType,
                Amount = detailDTO.Amount
            };

            db.BloodRequirementDetails.Add(entity);
            db.SaveChanges();

            detailDTO.DetailID = entity.DetailID;
        }

        // Xoá chi tiết theo DetailID
        public void DeleteDetail(int detailID)
        {
            var entity = db.BloodRequirementDetails.Find(detailID);
            if (entity != null)
            {
                db.BloodRequirementDetails.Remove(entity);
                db.SaveChanges();
            }
        }

        // Cập nhật chi tiết
        public void UpdateDetail(BloodRequirementDetailDTO detailDTO)
        {
            var entity = db.BloodRequirementDetails.Find(detailDTO.DetailID);
            if (entity != null)
            {
                entity.BloodType = detailDTO.BloodType;
                entity.Amount = detailDTO.Amount;

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Tìm kiếm bằng nhóm máu (blood type) => các lớp trên chưa phát triển
        //public List<BloodRequirementDetailDTO> SearchByBloodType(string bloodType)
        //{
        //    return db.BloodRequirementDetails
        //             .Where(d => d.BloodType == bloodType)
        //             .Select(d => new BloodRequirementDetailDTO
        //             {
        //                 DetailID = d.DetailID,
        //                 RequirementID = d.RequirementID,
        //                 BloodType = d.BloodType,
        //                 Amount = d.Amount
        //             })
        //             .ToList();
        //}

    }
}
