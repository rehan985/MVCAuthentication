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
























        //private List<UserAccount> _users;

        //    public UserAccountService()
        //{
        //    _users = new List<UserAccount>
        //    {
        //        new UserAccount { UserName = "admin" ,Password = "admin" ,Role = "Administrator"},
        //        new UserAccount { UserName = "user", Password = "user", Role = "User" }
        //    };
        //}
        //public UserAccount? GetByUserName(string username)
        //{
        //    return _users.FirstOrDefault(x => x.UserName == username);
        //}
    }
}
