using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AssignmentWebPlatTech.Controllers;
using AssignmentWebPlatTech.Models;

namespace AssignmentWebPlatTech.Models
{
    public class BALSignUp
    {

        SqlConnection con = new SqlConnection(@"Data Source=DEVELOPER-NILES\MSSQLSERVER01;Initial Catalog=AssignmentWebPlatTech;Integrated Security=True");

        // Method for Bind State
        public DataSet BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AssignmentWebPlat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "StateBind");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }


        // Method for Bind City
        public DataSet BindCity(int stateid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AssignmentWebPlat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CityBind");
            cmd.Parameters.AddWithValue("@StateID", stateid);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }

        // Method for SignUp
        public void SignUp(string name, DateTime dob, string address, int cityid, int pincode, string mobileno, string email,string pannumber,string panimage,string aadharno,string aadharfrontimage,string aadharbackimage,string gender)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AssignmentWebPlat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SignUp");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@DOB",dob );
            cmd.Parameters.AddWithValue("@Address",address );
            cmd.Parameters.AddWithValue("@CityID", cityid );
            cmd.Parameters.AddWithValue("@PinCode",pincode );
            cmd.Parameters.AddWithValue("@MobileNo",mobileno );
            cmd.Parameters.AddWithValue("@Email",email );
            cmd.Parameters.AddWithValue("@PanNumber",pannumber );
            cmd.Parameters.AddWithValue("@PanImage",panimage );
            cmd.Parameters.AddWithValue("@AadharNumber", aadharno);
            cmd.Parameters.AddWithValue("@AadharFrontImage",aadharfrontimage );
            cmd.Parameters.AddWithValue("@AadharBackImage",aadharbackimage );
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}