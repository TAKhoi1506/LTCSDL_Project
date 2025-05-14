using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BloodDetailBUS
    {
        private readonly BloodDetailDAL dal;
        public BloodDetailBUS()
        {
            dal = new BloodDetailDAL();
        }

        public List<BloodDetailDTO> GetAllBloodDetails()
        {
            return dal.GetAllBloodDetails();
        }

    }
}
