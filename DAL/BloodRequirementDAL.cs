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
        // Khởi tạo đối tượng DbContext để thao tác với CSDL
        private readonly MyContext db = new MyContext();

        // Lấy tất cả các yêu cầu máu trong CSDL
        public List<BloodRequirementDTO> GetAllRequirements()
        {
            // Truy vấn bảng BloodRequirements, chuyển đổi thành DTO rồi trả về danh sách
            return db.BloodRequirements
                     .Select(br => new BloodRequirementDTO
                     {
                         ID = br.ID,
                         RU_ID = br.RU_ID,
                         RequestDate = br.RequestDate,
                         SupplyDate = br.SupplyDate,
                         Status = br.Status
                     })
                     .ToList(); // Thực thi truy vấn và lấy kết quả
        }

        // Lấy các yêu cầu máu dựa trên mã đơn vị nhận (RU_ID)
        public List<BloodRequirementDTO> GetByUnitID(string ruId)
        {
            // Lọc các yêu cầu theo RU_ID, rồi chuyển thành DTO và trả về danh sách
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

        // Thêm mới một yêu cầu máu vào CSDL
        public int AddRequirement(BloodRequirementDTO brDTO)
        {
            // Tạo entity BloodRequirement từ DTO
            var entity = new BloodRequirement
            {
                RU_ID = brDTO.RU_ID,
                RequestDate = DateTime.Now, // Ngày yêu cầu lấy hiện tại
                SupplyDate = brDTO.SupplyDate,
                Status = string.IsNullOrEmpty(brDTO.Status) ? "Pending" : brDTO.Status,
                BloodRequirementDetails = new List<BloodRequirementDetail>()
            };

            // Thêm entity vào DbSet BloodRequirements
            db.BloodRequirements.Add(entity);
            db.SaveChanges(); // Lưu thay đổi, để entity.ID được tạo

            // Thêm chi tiết yêu cầu tương ứng vào bảng BloodRequirementDetails
            foreach (var detailDTO in brDTO.DetailList)
            {
                db.BloodRequirementDetails.Add(new BloodRequirementDetail
                {
                    RequirementID = entity.ID, // Liên kết chi tiết với yêu cầu vừa tạo
                    BloodType = detailDTO.BloodType,
                    Amount = detailDTO.Amount
                });
            }

            db.SaveChanges(); // Lưu các chi tiết yêu cầu vào CSDL
            return entity.ID; // Trả về ID của yêu cầu vừa thêm
        }

        // Xóa yêu cầu máu theo ID
        public void DeleteRequirement(int id)
        {
            // Tìm entity theo ID
            var entity = db.BloodRequirements.Find(id);
            if (entity != null)
            {
                // Nếu tìm thấy, xóa khỏi DbSet
                db.BloodRequirements.Remove(entity);
                db.SaveChanges(); // Lưu thay đổi vào CSDL
            }
        }

        // Cập nhật thông tin yêu cầu máu dựa trên DTO
        public void UpdateRequirement(BloodRequirementDTO brDTO)
        {
            // Tìm entity theo ID từ DTO
            var entity = db.BloodRequirements.Find(brDTO.ID);
            if (entity != null)
            {
                // Cập nhật các trường cần thiết
                entity.RU_ID = brDTO.RU_ID;
                entity.SupplyDate = brDTO.SupplyDate;
                entity.Status = brDTO.Status;

                // Đánh dấu entity này đã được chỉnh sửa
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges(); // Lưu thay đổi vào CSDL
            }
        }

        // Tìm kiếm yêu cầu theo mã đơn vị nhận (RU_ID)
        public List<BloodRequirementDTO> SearchRequirementByID(string unitID)
        {
            // Lọc các yêu cầu có RU_ID trùng với unitID truyền vào, rồi chuyển thành DTO
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

        // Sắp xếp kết quả theo tiêu chí truyền vào
        public List<(BloodRequirement Requirement, BloodRequirementDetail Detail)> Sort(string sortBy)
        {
            // Join 2 bảng BloodRequirements và BloodRequirementDetails theo RequirementID
            var query = from requirement in db.BloodRequirements
                        join detail in db.BloodRequirementDetails
                        on requirement.ID equals detail.RequirementID
                        select new { requirement, detail };

            // Xác định trường để sắp xếp dựa trên tham số sortBy
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

            // Thực thi truy vấn, chuyển từng kết quả thành tuple (Requirement, Detail)
            return query.ToList()
                        .Select(x => (x.requirement, x.detail))
                        .ToList();
        }

        // Cập nhật trạng thái của yêu cầu theo requirementId
        public bool UpdateStatus(int requirementId, string newStatus)
        {
            try
            {
                // Tìm yêu cầu theo ID
                var requirement = db.BloodRequirements.FirstOrDefault(r => r.ID == requirementId);
                if (requirement == null) return false;

                // Nếu trạng thái mới là "Approved", kiểm tra tồn kho
                if (newStatus == "Approved")
                {
                    // Lấy danh sách chi tiết yêu cầu máu của yêu cầu này
                    var details = db.BloodRequirementDetails
                                    .Where(d => d.RequirementID == requirementId)
                                    .ToList();

                    // Kiểm tra từng loại máu trong chi tiết
                    foreach (var detail in details)
                    {
                        // Tìm BloodStock theo BloodType
                        var stock = db.BloodStocks.FirstOrDefault(bs => bs.BloodType == detail.BloodType);
                        if (stock == null || stock.Amount < detail.Amount)
                        {
                            // Không đủ máu => không được cập nhật trạng thái
                            return false;
                        }
                    }
                }

                // Nếu đủ máu hoặc trạng thái không phải "Approved" => cập nhật
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
