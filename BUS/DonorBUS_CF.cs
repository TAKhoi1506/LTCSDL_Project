using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BUS
{
    public class DonorBUS_CF
    {
        private DonorDAL_CF donorDAL = new DonorDAL_CF();

        public bool AddDonor(Donor donor)
        {
            return donorDAL.AddDonor(donor);
        }


        public List<Donor> GetAllDonors()
        {
            return donorDAL.GetAllDonors();
        }

    }
}
