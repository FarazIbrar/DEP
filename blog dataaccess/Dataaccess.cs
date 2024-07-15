

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Modals;

namespace blogdataaccess
{
    public class Dataaccess
    {

        public static void savebloginformation(Modalstudent ms)
        {
            SqlConnection con = Dbhelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_saveblog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", ms.firstname);
            cmd.Parameters.AddWithValue("@email", ms.email);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void saveblogAddpost(Addpost ap)
        {
            SqlConnection con = Dbhelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("saveBlogpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", ap.Title);
            cmd.Parameters.AddWithValue("@Category", ap.Category);
            cmd.Parameters.AddWithValue("@Content", ap.Content);

            cmd.ExecuteNonQuery();
            con.Close();
        }








        public static void deletebloginformation(string id)
        {

            SqlConnection con = Dbhelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deletepost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", id);


            cmd.ExecuteNonQuery();
            con.Close();

        }




        public static void updatebloginformation()
        {


        }


        public static List<Modalstudent> getlogininformation()
        {
            SqlConnection con = Dbhelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_get_blog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Modalstudent> liststudents = new List<Modalstudent>();

            while (reader.Read())
            {

                Modalstudent student = new Modalstudent();
                student.stuid = Convert.ToInt32(reader["stuid"]);
                student.firstname = reader["firstname"].ToString();
                student.email = reader["email"].ToString();
                liststudents.Add(student);

            }
            con.Close();
            return liststudents;


        }


        public static List<Addpost> getsaveblogininformation()
        {
            SqlConnection con = Dbhelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_get_Addblogpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Addpost> listBlogpost = new List<Addpost>();

            while (reader.Read())
            {

                Addpost Blogpost = new Addpost();

                Blogpost.Title = reader["Title"].ToString();
                Blogpost.Category = reader["Category"].ToString();
                Blogpost.Content = reader["Content"].ToString();

                listBlogpost.Add(Blogpost);

            }
            con.Close();
            return listBlogpost;


        }


    }
}