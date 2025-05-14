using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DTO;

namespace DAL
{
    public class BloodDetailDAL
    {
        private readonly MyContext db;
        public BloodDetailDAL()
        {
            db = new MyContext();
        }

        public List<BloodDetailDTO> GetAllBloodDetails()
        {
            return db.BloodDetails.Select(bd => new BloodDetailDTO
            {
                BloodDetailID = bd.BloodDetailID,
                BloodID = bd.BloodID,
                CollectionDate = bd.CollectionDate,
                ExpiredDate = bd.ExpiredDate,
                Status = bd.Status,
                DonorID = bd.DonorID
            }).ToList();
        }
    }
}
