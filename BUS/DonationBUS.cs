using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class DonationBUS
    {
        private DonationDAL dal = new DonationDAL();

        public bool AddDonation(DonationDTO donation)
        {
            return dal.AddDonation(donation);
        }

        public List<DonationDTO> GetAllDonations()
        {
            return dal.GetAllDonations();
        }
    }
}
