using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using WebAp_MVC_L45_RadioDrop_5223.Models;

namespace WebAp_MVC_L45_RadioDrop_5223.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MVC_JQuery"].ConnectionString);

        public ActionResult CreateView()
        {
            return View();
        }

        public void SaveEmployee(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@address", obj.address);
            cmd.Parameters.AddWithValue("@age", obj.age);
            cmd.Parameters.AddWithValue("@gender", obj.gender);
            cmd.Parameters.AddWithValue("@country", obj.country);
            cmd.Parameters.AddWithValue("@state", obj.state);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public JsonResult GetEmployee()
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

        public JsonResult GetCountry()
        {
            string Data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblcountry_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Data = JsonConvert.SerializeObject(dt);
            //return data;
            return Json(Data, JsonRequestBehavior.AllowGet);// string format me na jaakar json format hi data jaa raha hai.
        }

        public JsonResult GetState(int cid)
        {
            string Data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblstate_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid",cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Data = JsonConvert.SerializeObject(dt);
            //return data;
            return Json(Data, JsonRequestBehavior.AllowGet);// string format me na jaakar json format hi data jaa raha hai.
        }




        public void DeleteEmployee(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "DELETE");
            cmd.Parameters.AddWithValue("@empid", obj.empid);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult EditEmployee(Employee obj)
        {
            string Data = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "EDIT");
            cmd.Parameters.AddWithValue("@empid", obj.empid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            Data = JsonConvert.SerializeObject(dt);
            //return data;
            return Json(Data, JsonRequestBehavior.AllowGet);// string format me na jaakar json format hi data jaa raha hai.
        }


        public void UpdateEmployee(Employee obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "UPDATE");
            cmd.Parameters.AddWithValue("@empid", obj.empid);
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@address", obj.address);
            cmd.Parameters.AddWithValue("@age", obj.age);
            cmd.Parameters.AddWithValue("@gender", obj.gender);
            cmd.Parameters.AddWithValue("@country", obj.country);
            cmd.Parameters.AddWithValue("@state", obj.state);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}