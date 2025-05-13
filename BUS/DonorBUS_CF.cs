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
            if (string.IsNullOrWhiteSpace(donor.Username) || string.IsNullOrWhiteSpace(donor.Password))
                return false;

            return donorDAL.InsertDonor(donor);
        }

        //public bool Login(string username, string password)
        //{
        //    return donorDAL.Login(username, password);
        //}


        //Update bởi admin
        public bool UpdateByAdmin(DonorDTO donor)
        {
            if (donor == null || string.IsNullOrWhiteSpace(donor.Username) || donor.DonorID <= 0)
            {
                return false;
            }
            return donorDAL.UpdateDonorByAdmin(donor);
        }

        //Update bởi donors
        public bool UpdateByDonor(DonorDTO donor)
        {
            if (donor == null || string.IsNullOrWhiteSpace(donor.Username))
            {
                return false;
            }
            return donorDAL.UpdateDonorByDonor(donor);
        }



    }
}
