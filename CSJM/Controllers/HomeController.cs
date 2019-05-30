using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using CSJM.Models;
namespace CSJM.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        ConnectionManager cm = new ConnectionManager();
        EncryptionManager em = new EncryptionManager();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Facilities()
        {
            return View();
        }
        public ActionResult BoysHostels()
        {
            return View();
        }
        public ActionResult GirlsHostels()
        {
            return View();
        }

        public ActionResult CentralLibrary()
        {
            return View();
        }
        public ActionResult SportsAtheletics()
        {
            return View();
        }
        public ActionResult AuditoriumAndSeminarHalls()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(string txtuserid, string txtpass)
        {
            string cmd = "select *from TBL_AdminLogin where UserId='" + txtuserid + "' and Pass='" + txtpass + "'";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string UserID = dt.Rows[0]["UserId"].ToString();
                string pass = dt.Rows[0]["Pass"].ToString();
                string utype = dt.Rows[0]["Utype"].ToString().Trim();
                if ((UserID == txtuserid) && (pass == txtpass) && (utype == "Admin"))
                {
                    //set email for admin into session
                    Session["aid"] = txtuserid;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Administration ID or Password')</script>");
            }
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }
        public ActionResult Computer()
        {
            return View();
        }
        public ActionResult Applied()
        {
            return View();
        }

        public ActionResult Electronics()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Alumini()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Alumini(FormCollection frm)
        {
            string name = frm["txtname"].ToString();
            string rol = frm["txtrol"].ToString();
            string adhar = frm["txtadhar"].ToString();
            string mobile = frm["txtmobile"].ToString();
            string email = frm["txtemail"].ToString();
            string branch = frm["txtbranch"].ToString();
            string year = frm["txtyear"].ToString();
            string company = frm["txtcompany"].ToString();
            string postt = frm["txtpost"].ToString();
            string mycommand = "insert into Tab_Alumini values('" + name + "','" + rol + "','" + adhar + "','" + mobile + "','" + email + "','" + branch + "','" + year + "','" + company + "','" + postt + "','" + DateTime.Now.ToString() + "')";
            bool x = cm.ExecuteInsertUpdateOrDelete(mycommand);
            if (x == true)
            {
                TempData["msg"] = "<script>alert('Your Alumini Is Successfully Registered!!')</script>";
                return RedirectToAction("Alumini", "Home");
            }
            return View();
        }
        // Menu3 coding here.....
        
        public ActionResult AboutIns()
        {
            AboutUsMassage AM = new AboutUsMassage();
            string cmd = "select AboutIns from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                AM.dbAboutIns = dt.Rows[0]["AboutIns"].ToString();
            }
            return View(AM);

        }
        public ActionResult MissionVission()
        {
            AboutUsMassage AM = new AboutUsMassage();
            string cmd = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                AM.dbMission = dt.Rows[0]["Mission"].ToString();
                AM.dbVission = dt.Rows[0]["Vission"].ToString();
            }
            return View(AM);
        }
        public ActionResult PrincipaleMessage()
        {
            AboutUsMassage AM = new AboutUsMassage();
            string cmd = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AM.dbPrincipalMsg = dt.Rows[i]["PrinMsg"].ToString();
                    AM.dbPhotoes = "../Content/Photoes/" + dt.Rows[0]["Img"].ToString();
                }
            }
            return View(AM);

        }
        public ActionResult Principal()
        {
            AboutUsMassage am = new AboutUsMassage();
            string cmd = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    am.dbPrincipalMsg = dt.Rows[i]["PrinMsg"].ToString();
                    am.dbPhotoes = "../Content/Photoes/" + dt.Rows[0]["Img"].ToString();
                }
            }
            return View(am);
        }
        public ActionResult AcademicCommittee()
        {
            return View();
        }

        public ActionResult FinanceCommittee()
        {
            return View();
        }

        public ActionResult AciteCommittee()
        {
            return View();
        }

        public ActionResult ScholarshipCommittee()
        {
            return View();
        }

        public ActionResult SportsCommittee()
        {
            return View();
        }

        public ActionResult ProctorialCommittee()
        {
            return View();
        }
        public ActionResult SecurityGardeningCommittee()
        {
            return View();
        }

        public ActionResult TrainingPlacementCommittee()
        {
            return View();
        }
        public ActionResult AcademicProgram()
        {
            return View();

        }
        public ActionResult Syllabus()
        {
            return View();
        }
        public ActionResult Admission()
        {
            AboutUsMassage am = new AboutUsMassage();
            string cmd = "select Admission from TBL_AcademicProgram";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
               
                    am.dbAdmission = dt.Rows[0]["Admission"].ToString();
            }
            return View(am);
        }
        public ActionResult FeesStructure()
        {
            return View();
        }

        public ActionResult CulturalProgrames()
        {
            return View();
        }

        //Gallery Coding here............
        public ActionResult SportsGames()
        {
            return View();
        }
        public ActionResult NewsEvents()
        {
            return View();
        }

        public ActionResult CollageMedia()
        {
            return View();
        }


        //Gallery Coding End here....

    }

          
}
