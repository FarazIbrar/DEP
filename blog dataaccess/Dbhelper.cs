
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace blogdataaccess
{
    public class Dbhelper
    {
        public static SqlConnection GetConnection()
        {

            SqlConnection con = new SqlConnection("Data Source=FARAZ\\SQLEXPRESS;Initial Catalog=databaseproject;Integrated Security=True;Encrypt=False");
            return con;
        }

    }
}
