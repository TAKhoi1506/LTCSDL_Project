using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Update(ReceivingUnitDTO dto)
        {
            return dal.UpdateReceivingUnit(dto);
        }

        public bool Delete(string ruId)
        {
            return dal.DeleteReceivingUnit(ruId);
        }
    }

}
