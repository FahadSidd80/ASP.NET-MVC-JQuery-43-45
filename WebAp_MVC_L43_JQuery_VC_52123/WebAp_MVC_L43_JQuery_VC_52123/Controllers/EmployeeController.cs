using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WebAp_MVC_L43_JQuery_VC_52123.Controllers
{
    public class EmployeeController : Controller
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MVC_JQuery"].ConnectionString);
        public ActionResult CreateView()//  CreateView is called as Action when mehtod ka type ActionResult hoga.  and har action jiska type actionresult hoga wo view jaroor return karega ys fir jo action view return karega uska type actionresult jaroor hoga.
        {
            return View();
        }

        public void SaveEmployee(string name, string address, int age)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.ExecuteNonQuery();
            con.Close();
        }


       
        public JsonResult DisplayEmployee()
        {
            string Data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GET");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Data = JsonConvert.SerializeObject(dt);
            //return data;
            return Json(Data, JsonRequestBehavior.AllowGet);// string format me na jaakar json format hi data jaa raha hai.
        }


        public void DeleteEmployee(string empid)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "DELETE");
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult EditEmployee(int empid)
        {
            string Data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "EDIT");
            cmd.Parameters.AddWithValue("@empid", empid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Data = JsonConvert.SerializeObject(dt);
            //return data;
            return Json(Data, JsonRequestBehavior.AllowGet);// string format me na jaakar json format hi data jaa raha hai.
        }


        public void UpdateEmployee(int empid,string name, string address, int age)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "UPDATE");
            cmd.Parameters.AddWithValue("@empid",empid );
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}