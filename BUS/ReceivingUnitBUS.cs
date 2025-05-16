using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class ReceivingUnitBUS
    {
        private ReceivingUnitDAL dal = new ReceivingUnitDAL();

        public List<ReceivingUnitDTO> GetAll()
        {
            return dal.GetAllReceivingUnits();
        }

        public ReceivingUnitDTO GetById(string ruId)
        {
            return dal.GetById(ruId);
        }

        public bool Add(ReceivingUnitDTO dto)
        {
            return dal.AddReceivingUnit(dto);
        }

        // RU đăng nhập 
        public bool Update(ReceivingUnitDTO dto, string newPassword)
        {
            UserAccountDAL accountDAL = new UserAccountDAL();
            var existingAccount = accountDAL.GetUserByUsername(dto.Username);

            bool isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, existingAccount.Password);
            if (!isCurrentPasswordValid)
                return false;

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                dto.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }
            else
            {
                // Không thay đổi mật khẩu => dùng lại mật khẩu đã hash trong DB
                dto.Password = existingAccount.Password;
            }

            return dal.UpdateReceivingUnit(dto);
        }

        public bool Delete(string ruId)
        {
            return dal.DeleteReceivingUnit(ruId);
        }

        // admin đăng nhập 
        public bool AdminUpdate(ReceivingUnitDTO dto)
        {
            return dal.AdminUpdateReceivingUnit(dto);
        }

        // search
        public List<ReceivingUnitDTO> SearchRuByID(string ruId)
        {
            return dal.SearchRuByID(ruId);
        }

        // sort
        public List<ReceivingUnitDTO> GetSorted(string sortBy)
        {
            return dal.GetSortedReceivingUnits(sortBy);
        }
    }
}
