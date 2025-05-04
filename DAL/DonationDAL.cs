using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class DonationDAL
    {
        public bool AddDonation(DonationDTO donation)
        {
            using (var context = new MyContext())
            {
                var newDonation = new Donation
                {
                    DonorID = donation.DonorID,
                    EventID = donation.EventID
                };

                context.Donations.Add(newDonation);
                return context.SaveChanges() > 0;
            }
        }

        public List<DonationDTO> GetAllDonations()
        {
            using (var context = new MyContext())
            {
                return context.Donations
                    .Select(d => new DonationDTO
                    {
                        DonationID = d.DonationID,
                        DonorID = d.DonorID,
                        EventID = d.EventID
                    }).ToList();
            }
        }
    }
}
