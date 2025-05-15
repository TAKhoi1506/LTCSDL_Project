using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class BloodRequirementDetailDAL
    {
        // Khởi tạo context để tương tác với database
        private readonly MyContext db = new MyContext();

        // Lấy toàn bộ chi tiết yêu cầu máu từ database
        public List<BloodRequirementDetailDTO> GetAllDetails()
        {
            // Truy vấn bảng BloodRequirementDetails, chuyển dữ liệu sang DTO rồi trả về dạng List
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

        // Lấy danh sách chi tiết yêu cầu theo ID của yêu cầu chính (RequirementID)
        public List<BloodRequirementDetailDTO> GetByRequirementID(int requirementID)
        {
            // Lọc dữ liệu theo RequirementID, chuyển sang DTO rồi trả về danh sách
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

        // Thêm mới một chi tiết yêu cầu máu vào database
        public void AddDetail(BloodRequirementDetailDTO detailDTO)
        {
            // Chuyển DTO thành Entity để thêm vào DB
            var entity = new BloodRequirementDetail
            {
                RequirementID = detailDTO.RequirementID,
                BloodType = detailDTO.BloodType,
                Amount = detailDTO.Amount
            };

            // Thêm Entity mới vào context và lưu thay đổi vào database
            db.BloodRequirementDetails.Add(entity);
            db.SaveChanges();

            // Cập nhật lại ID chi tiết vừa thêm vào DTO (nếu cần dùng tiếp)
            detailDTO.DetailID = entity.DetailID;
        }

        // Xóa chi tiết yêu cầu theo DetailID
        public void DeleteDetail(int detailID)
        {
            // Tìm Entity tương ứng với ID truyền vào
            var entity = db.BloodRequirementDetails.Find(detailID);
            if (entity != null)
            {
                // Nếu tìm thấy, xóa Entity và lưu thay đổi
                db.BloodRequirementDetails.Remove(entity);
                db.SaveChanges();
            }
        }

        // Cập nhật thông tin chi tiết yêu cầu máu
        public void UpdateDetail(BloodRequirementDetailDTO detailDTO)
        {
            // Tìm Entity trong DB theo DetailID từ DTO
            var entity = db.BloodRequirementDetails.Find(detailDTO.DetailID);
            if (entity != null)
            {
                // Cập nhật các trường thông tin
                entity.BloodType = detailDTO.BloodType;
                entity.Amount = detailDTO.Amount;

                // Đánh dấu Entity này đã bị thay đổi
                db.Entry(entity).State = EntityState.Modified;

                // Lưu các thay đổi vào database
                db.SaveChanges();
            }
        }

        // Phần này là hàm tìm kiếm theo nhóm máu (chưa được sử dụng)
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
