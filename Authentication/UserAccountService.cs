using System.Data.SqlClient;
using System.Data;

namespace MVCAuthentication.Authentication
{
    public class UserAccountService
    {

        public static UserAccount GetUserByName(string UserName)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetUserByName", con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            UserAccount ee = new UserAccount();
            while(sdr.Read())
            {
                ee.Password = sdr["Password"].ToString();
                ee.Role = sdr["Role"].ToString();

            }
            con.Close();
            return ee;

        }
        public static void SaveRegisterFrom(UserAccount ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveRegistrationForm", con);
            cmd.Parameters.AddWithValue("@Name", ee.UserName);

            cmd.Parameters.AddWithValue("Password", ee.Password);
            cmd.Parameters.AddWithValue("Role", ee.Role);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
