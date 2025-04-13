using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonorDAL
    {
        private string connectionString = "Data Source=MSI\\NHAN;Initial Catalog=bloodbank;Integrated Security=True";

        public bool AddDonor(Donor donor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Donor (Username, Password, FullName, DateOfBirth, BloodType, Gender, PhoneNumber, Email, LastDonationDate,Address) " +
                               "VALUES (@Username, @Password, @FullName, @DateOfBirth, @BloodType, @Gender, @PhoneNumber, @Email, @LastDonationDate,@Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", donor.Username);
                cmd.Parameters.AddWithValue("@Password", donor.Password);
                cmd.Parameters.AddWithValue("@FullName", donor.FullName);
                cmd.Parameters.AddWithValue("@DateOfBirth", donor.DateOfBirth);
                cmd.Parameters.AddWithValue("@BloodType", donor.BloodType);
                cmd.Parameters.AddWithValue("@Gender", donor.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", donor.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@LastDonationDate", donor.LastDonationDate);
                cmd.Parameters.AddWithValue("@Address", donor.Address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertDonor(Donor donor)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Donor (Username, Password, FullName, Gender, Address, DateOfBirth, LastDonationDate, PhoneNumber, Email) 
                                 VALUES (@Username, @Password, @FullName, @Gender, @Address, @DateOfBirth, @LastDonationDate, @PhoneNumber, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", donor.Username);
                cmd.Parameters.AddWithValue("@Password", donor.Password);
                cmd.Parameters.AddWithValue("@FullName", donor.FullName);
                cmd.Parameters.AddWithValue("@Gender", donor.Gender);
                cmd.Parameters.AddWithValue("@Address", donor.Address);
                cmd.Parameters.AddWithValue("@DateOfBirth", donor.DateOfBirth);
                cmd.Parameters.AddWithValue("@LastDonationDate", donor.LastDonationDate);
                cmd.Parameters.AddWithValue("@PhoneNumber", donor.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", donor.Email);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable GetAllDonors()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Donor";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public bool Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Donor WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }
    }
}
