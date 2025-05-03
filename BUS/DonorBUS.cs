using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
using DTO;

namespace BUS
{
    public class DonorBUS
    {
        private DonorDAL donorDAL = new DonorDAL();

        public bool AddDonor(DonorDTO donor)
        {
            return donorDAL.AddDonor(donor);
        }

        public List<DonorDTO> GetAllDonors()
        {
            return donorDAL.GetAllDonors();
        }

        public bool RegisterDonor(DonorDTO donor)
        {
            //if (string.IsNullOrWhiteSpace(donor.Username) || string.IsNullOrWhiteSpace(donor.Password))
            //    return false;

            //return donorDAL.InsertDonor(donor);
            return true;
        }
        
    }
}
