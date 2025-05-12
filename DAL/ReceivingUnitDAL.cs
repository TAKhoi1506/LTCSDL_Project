using DAL.Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class ReceivingUnitDAL
    {
        private MyContext db = new MyContext();

        public List<ReceivingUnitDTO> GetAllReceivingUnits()
        {
            return db.ReceivingUnits.Select(u => new ReceivingUnitDTO
            {
                RU_ID = u.RU_ID,
                UnitName = u.UnitName,
                ContactName = u.ContactName,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                UnitType = u.UnitType
            }).ToList();
        }

        public ReceivingUnitDTO GetById(string ruId)
        {
            var u = db.ReceivingUnits.Find(ruId);
            if (u == null) return null;

            return new ReceivingUnitDTO
            {
                RU_ID = u.RU_ID,
                UnitName = u.UnitName,
                ContactName = u.ContactName,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                UnitType = u.UnitType
            };
        }

        public bool AddReceivingUnit(ReceivingUnitDTO dto)
        {
            // Kiểm tra trùng Username
            var existingAccount = db.UserAccounts.FirstOrDefault(u => u.Username == dto.Username);
            if (existingAccount != null)
            {
                throw new Exception("Username already exists.");
            }

            // sử dụng transaction để rollback nếu có lỗi
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tạo ReceivingUnit entity
                    var entity = new ReceivingUnit
                    {
                        RU_ID = dto.RU_ID,
                        UnitName = dto.UnitName,
                        ContactName = dto.ContactName,
                        Address = dto.Address,
                        PhoneNumber = dto.PhoneNumber,
                        Email = dto.Email,
                        UnitType = dto.UnitType
                    };

                    db.ReceivingUnits.Add(entity);
                    db.SaveChanges();

                    // 2. Tạo UserAccount liên kết với ReceivingUnit
                    var user = new UserAccount
                    {
                        Username = dto.Username,
                        Password = dto.Password,
                        Role = "ReceivingUnit",
                        ObjectID = entity.RU_ID // Gán RU_ID làm ObjectID
                    };

                    db.UserAccounts.Add(user);
                    db.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Add failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateReceivingUnit(ReceivingUnitDTO dto)
        {
            try
            {
                var entity = db.ReceivingUnits.Find(dto.RU_ID);
                if (entity == null) return false;

                entity.UnitName = dto.UnitName;
                entity.ContactName = dto.ContactName;
                entity.Address = dto.Address;
                entity.PhoneNumber = dto.PhoneNumber;
                entity.Email = dto.Email;
                entity.UnitType = dto.UnitType;


                var userAccount = db.UserAccounts.FirstOrDefault(u => u.ObjectID == dto.RU_ID && u.Role == "ReceivingUnit");

                // kiểm tra xem username đã tồn tại chưa
                var exists = db.UserAccounts.Any(u => u.Username == dto.Username && u.AccountID != userAccount.AccountID);
                if (exists)
                    throw new Exception("Username already exists.");


                if (userAccount != null)
                {
                    userAccount.Username = dto.Username;
                    userAccount.Password = dto.Password;
                }

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteReceivingUnit(string ruId)
        {
            try
            {
                var entity = db.ReceivingUnits.Find(ruId);
                if (entity == null) return false;

                db.ReceivingUnits.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Admin update inf 
        public bool AdminUpdateReceivingUnit(ReceivingUnitDTO dto)
        {
            try
            {
                var entity = db.ReceivingUnits.Find(dto.RU_ID);
                if (entity == null)
                    return false;

                // Cập nhật thông tin cơ bản
                entity.UnitName = dto.UnitName;
                entity.ContactName = dto.ContactName;
                entity.Address = dto.Address;
                entity.PhoneNumber = dto.PhoneNumber;
                entity.Email = dto.Email;
                entity.UnitType = dto.UnitType;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Search 
        public List<ReceivingUnitDTO> SearchRuByID(string ruId)
        {
            return db.ReceivingUnits
               .Where(u => u.RU_ID.Contains(ruId))
               .Select(u => new ReceivingUnitDTO
               {
                   RU_ID = u.RU_ID,
                   UnitName = u.UnitName,
                   ContactName = u.ContactName,
                   Address = u.Address,
                   PhoneNumber = u.PhoneNumber,
                   Email = u.Email,
                   UnitType = u.UnitType
               }).ToList();
        }

        // mặc định sắp xếp tăng 
        public List<ReceivingUnitDTO> GetSortedReceivingUnits(string sortBy)
        {
            var query = db.ReceivingUnits.AsQueryable();

            // Chọn thuộc tính để sắp xếp
            switch (sortBy)
            {
                case "Unit ID":
                    query = query.OrderBy(r => r.RU_ID);
                    break;
                case "Unit name":
                    query = query.OrderBy(r => r.UnitName);
                    break;
                case "Unit type":
                    query = query.OrderBy(r => r.UnitType);
                    break;
                default:
                    query = query.OrderBy(r => r.RU_ID); // mặc định
                    break;
            }

            return query.Select(r => new ReceivingUnitDTO
            {
                RU_ID = r.RU_ID,
                UnitName = r.UnitName,
                ContactName = r.ContactName,
                Address = r.Address,
                PhoneNumber = r.PhoneNumber,
                Email = r.Email,
                UnitType = r.UnitType,
            }).ToList();
        }
    }
}
