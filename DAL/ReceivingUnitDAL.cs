using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

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
                //Username = u.Username,
                //Password = u.Password,
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
                //Username = u.Username,
                //Password = u.Password,
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
            try
            {
                var entity = new ReceivingUnit
                {
                    RU_ID = dto.RU_ID,
                    //Username = dto.Username,
                    //Password = dto.Password,
                    UnitName = dto.UnitName,
                    ContactName = dto.ContactName,
                    Address = dto.Address,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    UnitType = dto.UnitType
                };

                db.ReceivingUnits.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReceivingUnit(ReceivingUnitDTO dto)
        {
            try
            {
                var entity = db.ReceivingUnits.Find(dto.RU_ID);
                if (entity == null) return false;

                //entity.Username = dto.Username;
                //entity.Password = dto.Password;
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
    }
}
