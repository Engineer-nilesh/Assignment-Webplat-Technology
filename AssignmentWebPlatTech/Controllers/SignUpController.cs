using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Configuration;
using AssignmentWebPlatTech.Controllers;
using System.Data.SqlClient;
using AssignmentWebPlatTech.Models;

namespace AssignmentWebPlatTech.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp

        BALSignUp balsignup = new BALSignUp();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUpCreate()
        {
          
            Statebind();
         
            return View();
        }


        [HttpPost]
       
        public ActionResult SignUpCreate(HttpPostedFileBase aadharfrontfile, HttpPostedFileBase aadharbackfile, HttpPostedFileBase panfile,SignUp sign1)
        {

            if (aadharfrontfile != null & aadharfrontfile.ContentLength > 0)
            {
                string imgName = Path.GetFileName(aadharfrontfile.FileName);
                string imgext = Path.GetExtension(imgName);
                sign1.AadharfrontImage = "~/Images/" + imgName;
                imgName = Path.Combine(Server.MapPath("~/Images/"), imgName);
                aadharfrontfile.SaveAs(imgName);
            }
            if (aadharbackfile != null & aadharbackfile.ContentLength > 0)
            {
                string adharImgName = Path.GetFileName(aadharbackfile.FileName);
                string imgext = Path.GetExtension(adharImgName);
                sign1.AadharBackImage = "~/Images/" + adharImgName;
                adharImgName = Path.Combine(Server.MapPath("~/Images/"), adharImgName);
                aadharbackfile.SaveAs(adharImgName);
            }
            if (panfile != null & panfile.ContentLength > 0)
            {
                string panImgName = Path.GetFileName(panfile.FileName);
                string imgext = Path.GetExtension(panImgName);
                sign1.PanImage = "~/Images/" + panImgName;
                panImgName = Path.Combine(Server.MapPath("~/Images/"), panImgName);
                panfile.SaveAs(panImgName);
            }

            balsignup.SignUp(sign1.Name, sign1.DOB, sign1.Address, sign1.CityID,  sign1.PinCode, sign1.MobileNo, sign1.Email, sign1.PanNumber, sign1.PanImage, sign1.AadharNumber, sign1.AadharfrontImage, sign1.AadharBackImage, sign1.Gender);
             
            ViewData["Message"] = "<script>alert('Record Inserted Successfully....')</script>";

            return RedirectToAction("Index");
        }


        // State Bind 
        public void Statebind()
        {
           
            DataSet ds = balsignup.BindState();

            List<SelectListItem> statelist = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

             statelist.Add(new SelectListItem { Text = dr["State_Name"].ToString(), Value = dr["State_ID"].ToString() });
            }
            ViewBag.Statelist = statelist;
        }

        // City Bind 

        public JsonResult Citybind(int state_id)
        {

            DataSet ds = balsignup.BindCity(state_id);
            List<SelectListItem> citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem { Text = dr["City_Name"].ToString(), Value = dr["City_ID"].ToString() });
            }
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }


    }
}