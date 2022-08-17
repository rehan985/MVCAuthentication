using System.Data.SqlClient;
namespace MVCAuthentication.Authentication
{
    public class DBHelper
    {

            public static SqlConnection GetConnection()
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=UniversityDB;Integrated Security=True");
                return con;

            }

        
    }
}
