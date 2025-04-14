using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Domain;

namespace DAL
{
    //public class BloodRequirementDAL
    //{
    //    private string connectionString = @"Data Source=ZY-COM.;Initial Catalog=BloodBank;Integrated Security=True";

    //    private MyContext db = new MyContext();

    //    // Lấy danh sách tất cả yêu cầu và chuyển sang DTO => entity --> DTO 
    //    public List<BloodRequirement> GetAllRequirements()
    //    {
    //        var entities = db.BloodRequirements.ToList();

    //        List<BloodRequirement> result = new List<BloodRequirement>();

    //        foreach (var entity in entities)
    //        {
    //            result.Add(new BloodRequirement
    //            {
    //                ID = entity.ID,
    //                RU_ID = entity.RU_ID,
    //                RequestDate = entity.RequestDate,
    //                SupplyDate = entity.SupplyDate,
    //                Status = entity.Status,
    //                DetailList = entity.DetailList
    //            });
    //        }

    //        return result;
    //    }

    //    // Chuyển DTO --> entity 
    //    public bool InsertBloodRequirement(BloodRequirement requirement)
    //    {
    //        using (SqlConnection conn = new SqlConnection(connectionString))
    //        {
    //            string query = "INSERT INTO BloodRequirement (RU_ID, BloodType, Amount, SupplyDate) " +
    //                           "VALUES (@RU_ID, @BloodType, @Amount, @SupplyDate, @Status)";
    //            // RequestDate và Status đã có DEFAULT, không cần truyền vào
    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@RU_ID", requirement.RU_ID);
    //            cmd.Parameters.AddWithValue("@BloodType", requirement.BloodType);
    //            cmd.Parameters.AddWithValue("@Amount", requirement.Amount);
    //            cmd.Parameters.AddWithValue("@SupplyDate", requirement.SupplyDate);


    //            conn.Open();
    //            int rows = cmd.ExecuteNonQuery();
    //            return rows > 0;
    //        }
    //    }

    //}
    public class BloodRequirementDAL
    {
        private MyContext db = new MyContext();

        // Lấy danh sách tất cả yêu cầu (entity → entity, có thể map sang DTO ở tầng BUS)
        public List<BloodRequirement> GetAllRequirements()
        {
            return db.BloodRequirements
                     .Include("DetailList")
                     .Include("ReceivingUnit")
                     .ToList();
        }

        // Thêm mới yêu cầu và danh sách chi tiết (DTO → entity)
        public bool InsertBloodRequirement(BloodRequirement requirement)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Thêm requirement chính
                    db.BloodRequirements.Add(requirement);
                    db.SaveChanges();

                    // Giả sử các BloodRequirementDetail đã có sẵn trong requirement.DetailList
                    foreach (var detail in requirement.DetailList)
                    {
                        detail.RequirementID = requirement.ID; // thiết lập khoá ngoại
                        db.BloodRequirementDetails.Add(detail);
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }

}
