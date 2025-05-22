using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
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

            if (string.IsNullOrEmpty(dto.Password))
            {
                dto.Password = existingAccount.Password;
            }
            else
            {
                dto.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
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
