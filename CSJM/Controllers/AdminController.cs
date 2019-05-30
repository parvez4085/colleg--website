using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using CSJM.Models;

namespace CSJM.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        ConnectionManager cm = new ConnectionManager();
        EncryptionManager em = new EncryptionManager();
        AboutUsMassage am = new AboutUsMassage();
        DepartmentsTeacherData Dtd = new DepartmentsTeacherData();

        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {
                
            }
            else
            {
                return RedirectToAction("Adminlogin", "Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Change()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                return RedirectToAction("Adminlogin", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Change(string txtold, string txtnew, string txtconfirm)
        {
            if (txtnew == txtconfirm)
            {
                string command = "update Tab_Login set pass='" + em.EncryptData(txtnew) + "' where UserID='" + Session["aid"].ToString() + "'and pass='" + em.EncryptData(txtold) + "'";
                bool x = cm.ExecuteInsertUpdateOrDelete(command);
                if (x == true)
                {
                    Response.Write("<script>alert('Password Change Successfully');window.location.href='/Home/Adminlogin'</script>");
                }

                else
                {
                    Response.Write("<script>alert('Your Password Not Change')</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please Confirm Password')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            //Destroy the value of session.
            Session.Clear();
            Session.Abandon();
            return View();
        }
      
        // About Mangement Codeing here....


        public ActionResult AboutUsMgnt()
        {
            return View();
        }

        //It's code of AboutInstituteMgnt here..

        public ActionResult AboutInstituteMgnt()
        {
            ViewBag.result = "";
            string cmd = "select AboutIns from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string AboutIns = dt.Rows[0]["AboutIns"].ToString();
                if (AboutIns == "")
                {
                    am.dbAboutIns = "";
                    ViewBag.SaveButton = "";
                    ViewBag.EditButton = "disabled";
                }
                else
                {
                    am.dbAboutIns = AboutIns;
                    ViewBag.SaveButton = "disabled";
                    ViewBag.EditButton = "";
                }
            }
            return View(am);
        }
        [HttpPost]
        public ActionResult AboutInstituteMgnt( string txtAboutIns)
        {
            int id = 0;
            string Mission = "";
            string Vission = "";
            string PrinMsg = "";
            string RuleandRegu = "";
            string Infrastructure = "";
            string Img = "";
            string query="select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id = int.Parse(dt.Rows[i]["IdMsg"].ToString());
                    Mission = dt.Rows[i]["Mission"].ToString();
                    Vission = dt.Rows[i]["Vission"].ToString();
                    PrinMsg = dt.Rows[i]["PrinMsg"].ToString();
                    RuleandRegu = dt.Rows[i]["RuleandRegu"].ToString();
                    Infrastructure = dt.Rows[i]["Infrastructure"].ToString();
                    Img = dt.Rows[i].ToString();
                }
            }
                if ((Mission == "") && (Vission == "")&&(PrinMsg=="")&&(RuleandRegu==""))
                {
                    string cmd = "insert into TBL_AboutUs(IdMsg,AboutIns,Mission,Vission,PrinMsg,RuleandRegu,Infrastructure,Img,dt) values('" + id + "','" + txtAboutIns + "','" + Mission + "','" + Vission + "','" + PrinMsg + "','" + RuleandRegu + "','" + Infrastructure + "','" + Img + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        ViewBag.result = " Data have been saved Successfully";
                    }
                    else
                    {
                        ViewBag.result = " Data have been Not saved";
                    }
                }
            else
            {
                string cmd = "update TBL_AboutUs set AboutIns='" + txtAboutIns + "' where IdMsg="+id;
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    ViewBag.result = " Data have been saved Successfully";
                }
                else
                {
                    ViewBag.result = " Data have been Not saved";
                }

            }
                am.dbAboutIns = "";
            return View(am);
        }

        //it's code of Mission Management here...

        public ActionResult MissionMgnt()
        {
            ViewBag.result = "";
            string cmd = "select Mission from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string Mission = dt.Rows[0]["Mission"].ToString();
                if (Mission == "")
                {
                    am.dbMission = "";
                    ViewBag.SaveButton = "";
                    ViewBag.EditButton = "disabled";
                }
                else
                {
                    am.dbMission = Mission;
                    ViewBag.SaveButton = "disabled";
                    ViewBag.EditButton = "";
                }
            }
            return View(am);
        }
        [HttpPost]
          public ActionResult MissionMgnt( string txtMission)
        {
            int id=0;
            string AboutIns = "";
            string Vission = "";
            string PrinMsg = "";
            string RuleandRegu = "";
            string Infrastructure = "";
            string Img = "";
            string query = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AboutIns = dt.Rows[i]["AboutIns"].ToString();
                    Vission = dt.Rows[i]["Mission"].ToString();
                    PrinMsg = dt.Rows[i]["PrinMsg"].ToString();
                    RuleandRegu = dt.Rows[i]["RuleandRegu"].ToString();
                    Infrastructure = dt.Rows[i]["Infrastructure"].ToString();
                    Img = dt.Rows[i].ToString();
                }
            }
               if((AboutIns=="")&&(Vission=="")&&(PrinMsg=="")&&(RuleandRegu==""))
               {
                   string cmd = "insert into TBL_AboutUs(IdMsg,AboutIns,Mission,Vission,PrinMsg,RuleandRegu,Infrastructure,Img,dt) values('"+id+"','" + AboutIns + "','" + txtMission + "','" + Vission + "','" + PrinMsg + "','" + RuleandRegu + "','" + Infrastructure + "','" + Img + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    ViewBag.result = " Data have been saved Successfully";
                }
                else
                {
                    ViewBag.result = " Data have been Not saved";
                }
            }
            else
            {
                string cmd = "update TBL_AboutUs set Mission='" + txtMission + "' where IdMsg="+id;
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    ViewBag.result = " Data have been saved Successfully";
                }
                else
                {
                    ViewBag.result = " Data have been Not saved";
                }

            }
               am.dbMission = "";
            return View(am);
        }
    
        // it's code of Vission Magnagement here.....

        public ActionResult VisionMgnt()
        {
            ViewBag.result = "";
            string cmd = "select Vission from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string Vission = dt.Rows[0]["Vission"].ToString();
                if (Vission == "")
                {
                    am.dbVission = "";
                    ViewBag.SaveButton = "";
                    ViewBag.EditButton = "disabled";
                }
                else
                {
                    am.dbVission = Vission;
                    ViewBag.SaveButton = "disabled";
                    ViewBag.EditButton = "";
                }
            }
            return View(am);
        }

        [HttpPost]
        public ActionResult VisionMgnt( string txtVission)
        {
            int id = 0;
            string AboutIns = "";
            string Mission = "";
            string PrinMsg = "";
            string RuleandRegu = "";
            string Infrastructure = "";
            string Img = "";
            string query = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id = int.Parse(dt.Rows[i]["IdMsg"].ToString()); 
                    AboutIns = dt.Rows[i]["AboutIns"].ToString();
                    Mission = dt.Rows[i]["Mission"].ToString();
                    PrinMsg = dt.Rows[i]["PrinMsg"].ToString();
                    RuleandRegu = dt.Rows[i]["RuleandRegu"].ToString();
                    Infrastructure = dt.Rows[i]["Infrastructure"].ToString();
                    Img = dt.Rows[i].ToString();
                }
            }
            if ((AboutIns == "") && (Mission == "") && (PrinMsg == "") && (RuleandRegu == ""))
            {
                string cmd = "insert into TBL_AboutUs(AboutIns,Mission,Vission,PrinMsg,RuleandRegu,Infrastructure,Img,dt) values('" + id + "','" + AboutIns + "','" + Mission + "','" + txtVission + "','" + PrinMsg + "','" + RuleandRegu + "','" + Infrastructure + "','" + Img + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    ViewBag.result = " Data have been saved Successfully";
                }
                else
                {
                    ViewBag.result = " Data have been Not saved";
                }
            }

            else
            {
                string cmd = "update TBL_AboutUs set Vission='" + txtVission + "' where IdMsg=" +id;
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    ViewBag.result = " Data have been saved Successfully";
                }
                else
                {
                    ViewBag.result = " Data have been Not saved";
                }

            }
            am.dbVission = "";
            return View(am);
        }

        //it's code of Principals Message Management here...

        public ActionResult PrincipalsMessageMgnt()
        {
            ViewBag.result = "";
            string PrincipalMsg = "";
            string cmd = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     PrincipalMsg = dt.Rows[i]["PrinMsg"].ToString();
                }
                
                if (PrincipalMsg == "")
                {
                    am.dbPrincipalMsg = "";

                    ViewBag.SaveButton = "";
                    ViewBag.EditButton = "disabled";
                }
                else
                {
                    am.dbPrincipalMsg = PrincipalMsg;
                    
                    ViewBag.SaveButton = "disabled";
                    ViewBag.EditButton = "";
                }
            }
            return View(am);
        }
        [HttpPost]
        public ActionResult PrincipalsMessageMgnt(string txtPrincipalsMsg)
        {
            FileManager fm = new FileManager();
            HttpPostedFileBase file = Request.Files["txtfile"];
            int id = 0;
            string AboutIns = "";
            string Mission = "";
            string Vission = "";
            string RuleandRegu = "";
            string Infrastructure = "";
            string PrinMsg = "";
            string img = "";
            string query = "select *from TBL_AboutUs";
            System.Data.DataTable dt = cm.GetBulkRecord(query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id =int.Parse(dt.Rows[i]["IdMsg"].ToString());
                    AboutIns = dt.Rows[i]["AboutIns"].ToString();
                    Mission = dt.Rows[i]["Mission"].ToString();
                    Vission = dt.Rows[i]["Vission"].ToString();
                    PrinMsg = dt.Rows[i]["PrinMsg"].ToString();
                    RuleandRegu = dt.Rows[i]["RuleandRegu"].ToString();
                    Infrastructure = dt.Rows[i]["Infrastructure"].ToString();
                }
            }
            if ((AboutIns == "") && (Mission == "") && (Vission == "") && (PrinMsg=="")&&(RuleandRegu == ""))
            {
                if (file.FileName != "")
                {

                    string cmd = "insert into TBL_AboutUs(IdMsg,AboutIns,Mission,Vission,PrinMsg,RuleandRegu,Infrastructure,Img,dt) values('" + id + "','" + AboutIns + "','" + Mission + "','" + Vission + "','" + txtPrincipalsMsg + "','" + RuleandRegu + "','" + Infrastructure + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/Photoes/" + file.FileName));
                        ViewBag.result = " Data have been saved Successfully";
                    }
                    else
                    {
                        ViewBag.result = " Data have been Not saved";
                    }
                }
                else
                {
                    id++;
                    string cmd = "insert into TBL_AboutUs(IdMsg,AboutIns,Mission,Vission,PrinMsg,RuleandRegu,Infrastructure,Img,dt) values('" + id + "','" + AboutIns + "','" + Mission + "','" + Vission + "','" + txtPrincipalsMsg + "','" + RuleandRegu + "','" + Infrastructure + "','" + img + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                       
                        ViewBag.result = " Data have been saved Successfully";
                    }
                }
            }
            else
            {
                if (file.FileName != "")
                {
                    string cmd = "update TBL_AboutUs set PrinMsg='" + txtPrincipalsMsg + "',Img='" + file.FileName + "' where IdMsg=" + id;
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/Photoes/" + file.FileName));
                        ViewBag.result = " Data have been Update Successfully";
                    }
                    else
                    {
                        ViewBag.result = " Data have been Not saved";
                    }
                }
                else
                {
                    string cmd = "update TBL_AboutUs set PrinMsg='" + txtPrincipalsMsg + "' where IdMsg=" + id;
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        ViewBag.result = " Data have been Update Successfully";
                    }
                }
            }
            am.dbPrincipalMsg = "";
            return View(am);

        }

        //it's code of rules and Regulation Management here.....

        public ActionResult RulesAndRegulationMgnt()
        {
            return View();
        }

        public ActionResult InstituteBrochureMgnt()
        {
            return View();
        }

        public ActionResult InfrastructureMgnt()
        {
            return View();
        }

        // 2nd menu bar Governance Management Coding here....

        public ActionResult AicteMgnt()
        {
            return View();
        }

        // 3th menu bar Governance Management Coding here....
        public ActionResult AcademicsMgnt()
        {
            ViewBag.result = "";

            return View();
        }
        [HttpPost]
        public ActionResult AcademicsMgnt(string txtGroupName, string txtCourse, string txtInteke)
        {
            string Admission = "";
            string cmd = "insert into TBL_AcademicProgram(GroupName,Course,Intake,Admission,dt) values('" + txtGroupName + "','" + txtCourse + "','" + txtInteke + "','"+Admission+"','" + DateTime.Now.ToString() + "')";
            if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
            {
                ViewBag.result = "Data has been saved Successfully";
            }
            else
            {
                ViewBag.result = "Data has Not been saved Successfully";
            }

            return View();
        }

        public ActionResult SyllabusMgnt()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]

        public ActionResult SyllabusMgnt(string BranchName, string Years)
        {
            HttpPostedFileBase file=Request.Files["txtfile"];
            if (file.FileName != "")
            {
                string cmd = "insert into TBL_Syllabus values('" + BranchName + "','" + Years + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    file.SaveAs(Server.MapPath("../Content/FdfFiles/" + file.FileName));
                    ViewBag.result = "File has been Updoaded Successfully";
                }
                else
                {
                    ViewBag.result = "File has Not been Updoaded Successfully";
                }
            }
            else
            {
                ViewBag.result = "File Path Incrrect and File Not Upload";
            }
            return View();
        }

        public ActionResult AdmissionMngt()
        {
            ViewBag.result = "";
            string Admission = "";
             string cmd = "select Admission from TBL_AcademicProgram";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     Admission = dt.Rows[i]["Admission"].ToString();

                }
                if (Admission == "")
                {
                    am.dbPrincipalMsg = "";
                    am.dbPhotoes = "";
                    ViewBag.SaveButton = "";
                    ViewBag.EditButton = "disabled";
                }
                else
                {
                    am.dbAdmission = Admission;
                    
                    ViewBag.SaveButton = "disabled";
                    ViewBag.EditButton = "";
                }
            }

            return View(am);
        }
        [HttpPost]
        public ActionResult AdmissionMngt( string txtAdmission)
        {
            AboutUsMassage am = new AboutUsMassage();
            string sn="";
            string groupName="";
            string Course="";
            string Intake="";
            string cmd = "select *from TBL_AcademicProgram";
            System.Data.DataTable dt = cm.GetBulkRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     sn = dt.Rows[i]["sn"].ToString();
                     groupName = dt.Rows[i]["GroupName"].ToString();
                }
                if ((sn == "") && (groupName == ""))
                {
                    string query = "insert into TBL_AcademicProgram(sn,GroupName,Course,Intake,Admission) values('" + groupName + "','" + Course + "','" + Intake + "''" + txtAdmission + "','"+DateTime.Now.ToString()+"')";
                    if (cm.ExecuteInsertUpdateOrDelete(query) == true)
                    {
                        ViewBag.result = "File has been Saved Successfully";
                        am.dbAdmission =txtAdmission;
                    }
                }
                else
                {
                    string command = "update TBL_AcademicProgram set Admission='" + txtAdmission + "' where sn=" + sn;
                    if (cm.ExecuteInsertUpdateOrDelete(command) == true)
                    {
                        ViewBag.result = "File has been Saved Successfully";
                        am.dbAdmission = txtAdmission;
                    }
                    else
                        ViewBag.result = "File has Not been Saved Successfully";
                         am.dbAdmission = "";
                }
              
            }
            
            return View(am);
        }

        public ActionResult FeesStructureMngt()
        {
            return View();
        }

        public ActionResult DeleteSyllabus()
        {
            return View();
        }
        

        // 4th menu bar Governance Management Coding here....

        public ActionResult DepartmentsMgnt()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";
            Dtd.dbId = "";
            Dtd.dbName = "";
            Dtd.dbPost = "";
            Dtd.dbOtherPost = "";
            Dtd.dbDepartment = "";
            Dtd.dbMobno = "";
            Dtd.dbEmailId = "";
            Dtd.dbQualification = "";
            Dtd.dbTeachingWorkingEx = "";
            Dtd.dbPic = "";
            ViewBag.cancelbutton = "disabled";
            ViewBag.updatebutton = "disabled";
            ViewBag.deletebutton = "disabled";
            ViewBag.savebutton = "disabled";
            ViewBag.searchbutton = "";
            ViewBag.addnewbutton = "";
           
            return View(Dtd);
        }
        [HttpPost]
        public ActionResult DepartmentsMgnt( FormCollection frm)
        {
             DataSet ds = new DataSet();
            FileManager fm = new FileManager();
            DepartmentsTeacherData Dtd = new DepartmentsTeacherData();
            try
            {
                string TeacherId = frm["txtId"].ToString();
                string TeacherName = frm["txtName"].ToString();
                string TeacherLname = frm["txtLastName"].ToString();
                string Post = frm["txtPost"].ToString();
                string OtherPost = frm["txtOtherPost"].ToString();
                string Department = frm["txtDepartment"].ToString();
                string MobNo = frm["txtMobNo"].ToString();                               
                string Emailid = frm["txtEmailId"].ToString();
                string Qualification = frm["txtQualification"].ToString();
                string TeacherWorkingEx = frm["txtTeacherWorkingEx"].ToString();
                HttpPostedFileBase file = Request.Files["txtfile"];
                string cbutton = frm["cbutton"].ToString();
                if (cbutton == "Search")
                {
                    String myquery = "Select * from TBL_TeachersDetails where Id=" + Convert.ToInt32(TeacherId);
                    System.Data.DataTable dt = cm.GetBulkRecord(myquery);                   
                    if (dt.Rows.Count > 0)
                    {
                        ViewBag.searchresult = "Teacher's Id Number Has Been Found";
                        Dtd.dbId = TeacherId;
                        Dtd.dbName = dt.Rows[0]["FirstName"].ToString();
                        Dtd.dbLastName = dt.Rows[0]["LastName"].ToString();
                        Dtd.dbPost = dt.Rows[0]["Post"].ToString();
                        Dtd.dbOtherPost = dt.Rows[0]["OtherPost"].ToString();
                        Dtd.dbDepartment = dt.Rows[0]["Department"].ToString();
                        Dtd.dbMobno = dt.Rows[0]["MobNo"].ToString();
                        Dtd.dbEmailId = dt.Rows[0]["Emailid"].ToString();
                        Dtd.dbQualification = dt.Rows[0]["Qualification"].ToString();
                        Dtd.dbTeachingWorkingEx = dt.Rows[0]["TeachingWorkingEx"].ToString();
                        Dtd.dbPic = "../Content/TeacherImg/" + dt.Rows[0]["Img"].ToString();
                        ViewBag.updateresult = "Note : You can perform delete or update or cancel operation";
                        ViewBag.cancelbutton = "";
                        ViewBag.updatebutton = "";
                        ViewBag.deletebutton = "";
                        ViewBag.savebutton = "disabled";
                        ViewBag.addnewbutton = "disabled";

                    }
                    else
                    {
                        ViewBag.updateresult = "";
                        ViewBag.searchresult = "Teacher's Id Number Has Not Found";
                        ViewBag.cancelbutton = "disabled";
                        ViewBag.updatebutton = "disabled";
                        ViewBag.deletebutton = "disabled";
                        ViewBag.savebutton = "disabled";

                        ViewBag.addnewbutton = "";
                    }

                }
                else if (cbutton == "Update")
                {
                    if (file.FileName != "")
                    {
                        string updatedata = "Update TBL_TeachersDetails set FirstName='" + TeacherName + "',LastName='" + TeacherLname + "',Post='"+Post+"',OtherPost='"+OtherPost+"',Department='"+Department+"',MobNo='" + MobNo + "',Emailid='" + Emailid + "',Qualification='"+Qualification+"',TeachingWorkingEx='"+TeacherWorkingEx+"',Img='" + file.FileName + "' where Id=" + Convert.ToInt32(TeacherId); 
                        
                        if (cm.ExecuteInsertUpdateOrDelete(updatedata) == true)
                        {
                            file.SaveAs(Server.MapPath("../Content/TeacherImg/" + file.FileName));
                        }


                    }
                    else
                    {
                        string updatedata = "Update TBL_TeachersDetails set FirstName='" + TeacherName + "',LastName='" + TeacherLname + "',Post='" + Post + "',OtherPost='" + OtherPost + "',Department='" + Department + "',MobNo='" + MobNo + "',Emailid='" + Emailid + "',Qualification='" + Qualification + "',TeachingWorkingEx='" + TeacherWorkingEx + "',Img='" + file.FileName + "' where Id=" + Convert.ToInt32(TeacherId); 
                        cm.ExecuteInsertUpdateOrDelete(updatedata);

                    }

                    Dtd.dbId = "";
                    Dtd.dbName = "";
                    Dtd.dbPost = "";
                    Dtd.dbOtherPost = "";
                    Dtd.dbDepartment = "";
                    Dtd.dbMobno = "";
                    Dtd.dbEmailId = "";
                    Dtd.dbQualification = "";
                    Dtd.dbTeachingWorkingEx = "";
                    Dtd.dbPic = "";

                    ViewBag.updateresult = "Data Has Been Updated Successfully with Id " + TeacherId;
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "";

                }
                else if (cbutton == "Cancel")
                {
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.searchbutton = "";
                    ViewBag.addnewbutton = "";
                    ViewBag.updateresult = "Add New Form and Search Cancelled";
                }
                else if (cbutton == "AddNew")
                {
                    ViewBag.cancelbutton = "";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "";
                    ViewBag.addnewbutton = "disabled";
                    ViewBag.searchbutton = "disabled";
                    ViewBag.updateresult = "New Blank Form Has Been Added Successfully";
                }
                else if (cbutton == "Save")
                {

                    if (file.FileName != "")
                    {
                        String query = "insert into TBL_TeachersDetails(Id,FirstName,LastName,Post,OtherPost,Department,MobNo,Emailid,Qualification,TeachingWorkingEx,Img,dt) values(" + TeacherId + ",'"
                            + TeacherName + "','" + TeacherLname + "','" + Post + "','" + OtherPost + "','" + Department + "','" + MobNo + "','" + Emailid + "','" + Qualification + "','" + TeacherWorkingEx + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                        bool x = cm.ExecuteInsertUpdateOrDelete(query);
                        if (x == true)
                        {
                            file.SaveAs(Server.MapPath("../Content/TeacherImg/" + file.FileName));
                        }


                    }
                    else
                    {
                        String query = "insert into TBL_TeachersDetails(Id,FirstName,LastName,Post,OtherPost,Department,MobNo,Emailid,Qualification,TeachingWorkingEx,Img,dt) values(" + TeacherId + ",'"
                             + TeacherName + "','" + TeacherLname + "','" + Post + "','" + OtherPost + "','" + Department + "','" + MobNo + "','" + Emailid + "','" + Qualification + "','" + TeacherWorkingEx + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                        cm.ExecuteInsertUpdateOrDelete(query);

                    }
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.searchbutton = "";
                    ViewBag.addnewbutton = "";
                    ViewBag.updateresult = "New Data has been Saved Successfully";
                    
                }
                else if (cbutton == "Delete")
                {

                    String delete = "delete from TBL_TeachersDetails where Id=" + TeacherId;
                    bool x = cm.ExecuteInsertUpdateOrDelete(delete);
                    if (x == true)
                    {
                        ViewBag.cancelbutton = "disabled";
                        ViewBag.updatebutton = "disabled";
                        ViewBag.deletebutton = "disabled";
                        ViewBag.savebutton = "disabled";
                        ViewBag.searchbutton = "";
                        ViewBag.addnewbutton = "";
                        ViewBag.updateresult = "Data has been Deleted Successfully with Id " + TeacherId;
                    }
                }

            }
            catch (Exception ex)
            { 
            
            }
            return View(Dtd);
        }

        // 6th menu bar Governance Management Coding here....

        public ActionResult TrainingAndPlacedMgnt()
        {
            return View();
        }
        // 7th menu bar Governance Management Coding here....
        public ActionResult FacilitiesResourcesMgnt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FacilitiesResourcesMgnt(string txtSeat)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != "")
                {
                    string cmd = "insert into TBL_BoysHostels values('" + txtSeat + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/HostelsImages/" + file.FileName));
                        ViewBag.result = "File has been Saved Successfully";
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult GirlsHotels()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GirlsHotels(string txtSeat)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != "")
                {
                    string cmd = "insert into TBL_GirlsHostels values('" + txtSeat + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/HostelsImages/" + file.FileName));
                        ViewBag.result = "File has been Saved Successfully";
                    }

                }
            }
            catch (Exception ex)
            {

            }
            
            return View();
        }
        public ActionResult CentralLibrary()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CentralLibrary(string txtText)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != "")
                {
                    string cmd = "insert into TBL_CentralLibrary values('" + txtText + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/CentralLibraryImg/" + file.FileName));
                        ViewBag.result = "File has been Saved Successfully";
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult SeminarHallsMngt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeminarHallsMngt(string txtTitle)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != "")
                {
                    string cmd = "insert into TBL_SeminarHalls values('" + txtTitle + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/SeminarHallsImg/" + file.FileName));
                        ViewBag.result = "File has been Saved Successfully";
                    }

                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }
        public ActionResult DeleteBoysHostels()
        {
            return View();
        }
        public ActionResult DeleteGirlsHostels()
        {
            return View();
        }

        // 8th menu bar Governance Management Coding here....

        public ActionResult Alumni()
        {
            return View();
        }
        // 9th menu bar Governance Management Coding here....

        public ActionResult ContactUsMgnt()
        {
            return View();
        }

        public ActionResult SliderMngt()
        {
            ViewBag.result = "";

            return View();
        }

        [HttpPost]
        public ActionResult SliderMngt(string txtfile)
        { 
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != null)
                {
                    string cmd = "insert into TBL_SliderImage values('" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);

                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/SliderImages/" + file.FileName));

                        ViewBag.result = "Image Saved Successfully";
                    }

                    else
                    {
                        ViewBag.result = "Image have not been saved";
                    }

                }
                else
                {
                    ViewBag.result = "Image file Path is not Correct";
                }
            }
            catch(Exception ex)
            {

            }

            return View();
        }


       
        public ActionResult DeleteImage()
        {
            ViewBag.result = "";
          
            return View();
        }
        public ActionResult Delete()
        {
            if(Request.QueryString["dt"]!=null)
            {
                string id=Request.QueryString["dt"].ToString();
                string cmd="delete from TBL_SliderImage where Sn='"+id+"'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteImage'</script>");
                }
                else
                {
                    ViewBag.result = "Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteImage'</script>");
                }
                
            }
            else if( Request.QueryString["dt1"]!=null)
            {
                string id1 = Request.QueryString["dt1"].ToString();
                string cmd = "delete from TBL_Syllabus where Sn='" + id1 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Syllabus have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteSyllabus'</script>");
                }
                else
                {
                    ViewBag.result = "Syllabus have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteSyllabus'</script>");
                }

            }

            else if (Request.QueryString["dt2"]!=null)
            {
                string id2 = Request.QueryString["dt2"].ToString();
                string cmd = "delete from TBL_OurCourses where Id='" + id2 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteCourses'</script>");
                }
                else
                {
                    ViewBag.result = "Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteCourses'</script>");
                }

            }

            else if (Request.QueryString["dt3"] != null)
            {
                string id3 = Request.QueryString["dt3"].ToString();
                string cmd = "delete from TBL_NoticBoard where Sn='" + id3 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Notic have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/NoticBoardNewsMngt'</script>");
                }
                else
                {
                    ViewBag.result = "Notic have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/NoticBoardNewsMngt'</script>");
                }

            }

            else if (Request.QueryString["dt4"] != null)
            {
                string id4 = Request.QueryString["dt4"].ToString();
                string cmd = "delete from TBL_NewsEvents where Sn='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "News and Event have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/NoticBoardNewsMngt'</script>");
                }
                else
                {
                    ViewBag.result = "News and Event have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/NoticBoardNewsMngt'</script>");
                }

            }

            else if (Request.QueryString["dt5"] != null)
            {
                string id4 = Request.QueryString["dt5"].ToString();
                string cmd = "delete from TBL_CulturalProgrames where Sn='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Cultural Programes Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/GellaryMgnt'</script>");
                }
                else
                {
                    ViewBag.result = "Cultural Programes Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/GellaryMgnt'</script>");
                }

            }

            else if (Request.QueryString["dt6"] != null)
            {
                string id4 = Request.QueryString["dt6"].ToString();
                string cmd = "delete from TBL_SportGame where Sn='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "SportGames Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/GellaryMgnt'</script>");
                }
                else
                {
                    ViewBag.result = "SportGames Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/GellaryMgnt'</script>");
                }

            }

            else if (Request.QueryString["dt7"] != null)
            {
                string id4 = Request.QueryString["dt7"].ToString();
                string cmd = "delete from TBL_NewsEvent where Sn='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "News Events Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/Gellary2'</script>");
                }
                else
                {
                    ViewBag.result = "News Events Image Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/Gellary2'</script>");
                }

            }

            else if (Request.QueryString["dt8"] != null)
            {
                string id4 = Request.QueryString["dt8"].ToString();
                string cmd = "delete from TBL_CollageMedia where Sn='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Collage Media Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/Gellary2'</script>");
                }
                else
                {
                    ViewBag.result = "Collage Media Image Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/Gellary2'</script>");
                }

            }

            else if (Request.QueryString["dt9"] != null)
            {
                string id4 = Request.QueryString["dt9"].ToString();
                string cmd = "delete from TBL_BoysHostels where Id='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Boys Hostels Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteBoysHostels'</script>");
                }
                else
                {
                    ViewBag.result = "Boys Hostels Image Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteBoysHostels'</script>");
                }

            }

            else if (Request.QueryString["dt10"] != null)
            {
                string id4 = Request.QueryString["dt10"].ToString();
                string cmd = "delete from TBL_GirlsHostels where Id='" + id4 + "'";
                if (cm.ExecuteInsertUpdateOrDelete(cmd))
                {
                    ViewBag.result = "Girls Hostels Image have been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteGirlsHostels'</script>");
                }
                else
                {
                    ViewBag.result = "Girls Hostels Image Image have Not been Delete By Admin";
                    Response.Write("<script>window.location.href='/Admin/DeleteGirlsHostels'</script>");
                }

            }
            
               
            return View();

        }

        public ActionResult OurCoureseMngt()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]
        public ActionResult OurCoureseMngt(string txtOurCourse, string txtIntake, string txtDuration)
        {
            FileManager fm=new FileManager();
            HttpPostedFileBase file = Request.Files["txtfile"];
            try
            {
                if (file.FileName != "")
                {
                    string cmd = "insert into TBL_OurCourses values('" + txtOurCourse + "','" + file.FileName + "','" + txtIntake + "','" + txtDuration + "','" + DateTime.Now.ToString() + "')";
                    bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                    if (x == true)
                    {
                        file.SaveAs(Server.MapPath("../Content/Photoes/" + file.FileName));
                        ViewBag.result = "Our Courses has been Saved Successfully";
                    }
                }
                else
                {
                    ViewBag.result = "File Path has Not been Correct";
                }
            }
            catch(Exception ex)
            {

            }

            return View();
        }
        public ActionResult DeleteCourses()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NoticBoardNewsMngt()
        {
            return View();
        }
       
        public ActionResult NoticBoard()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]
        public ActionResult NoticBoard(string txtNotics, string txtDate)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string cmd = "insert into TBL_NoticBoard values('" + txtNotics + "','" + file.FileName + "','" + txtDate + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/FdfFiles/" + file.FileName));
                    ViewBag.result = "Notic And File Saved Successfully";
                }
                else
                    ViewBag.result = "Notic And File have Not been Saved";
            }
            else
            {
                string img = "";
                string cmd = "insert into TBL_NoticBoard values('" + txtNotics + "','"+img+"','" + txtDate + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    ViewBag.result = "Notic Saved Successfully";
                }
                else
                    ViewBag.result = "Notic has Not been Saved";
            }
            return View();
        }
        public ActionResult NewsEvent()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult NewsEvent( string txtNews,string txtDate)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string query = "insert into TBL_NewsEvents values('" + txtNews + "','" + file.FileName + "','" + txtDate + "')";
                if(cm.ExecuteInsertUpdateOrDelete(query)==true)
                {
                   file.SaveAs(Server.MapPath("../Content/FdfFiles/" + file.FileName));
                    ViewBag.result = "News Event And File Saved Successfully";
                }
                else
                    ViewBag.result = "News Event And File have Not been Saved";
            }
            else
            {
                string fdf = "";

                string query = "insert into TBL_NewsEvents values('" + txtNews + "','"+fdf+"','" + txtDate + "')";
                if (cm.ExecuteInsertUpdateOrDelete(query) == true)
                {
                    ViewBag.result = "News Event has been Saved Successfully";
                }
                else
                    ViewBag.result = "News Event has Not been Saved";
            }

            return View();
        }
        public ActionResult GellaryMgnt()
        {
            return View();
        }
        public ActionResult Gellary2()
        {
            return View();
        }
        public ActionResult SportGame()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult SportGame( string txtTitle )
        {
            HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string cmd = "insert into TBL_SportGame values('" + txtTitle + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/Gallery/" + file.FileName));
                    ViewBag.result = "Sports And Games Image Saved Successfully";
                }
                else
                    ViewBag.result = "Sports And Games Image have Not been Saved";
            }
            else
            {
                string img = "";
                string cmd = "insert into TBL_SportGame values('" + txtTitle + "','" + img + "','" + DateTime.Now.ToString() + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    ViewBag.result = "Sports And Games Saved Successfully";
                }
                else
                    ViewBag.result = "Sports And Games has Not been Saved";
            }
            return View();
        }
        public ActionResult CulturalProgrames()
        {
            ViewBag.result = "";
            return View();
        }
        [HttpPost]
        public ActionResult CulturalProgrames(string txtTitle)
        {
             HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string cmd = "insert into TBL_CulturalProgrames values('" + txtTitle + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/Gallery/" + file.FileName));
                    ViewBag.result = "Cultural Programes And Image Saved Successfully";
                }
                else
                    ViewBag.result = "Cultural Programes And Image have Not been Saved";
            }
            else
            {
                string img = "";
                string cmd = "insert into TBL_CulturalProgrames values('" + txtTitle + "','" + img + "','" + DateTime.Now.ToString() + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    ViewBag.result = "Cultural Programes Saved Successfully";
                }
                else
                    ViewBag.result = "Cultural Programes has Not been Saved";
            }
            return View();
        }

        public ActionResult CollageMedia()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]
        public ActionResult CollageMedia(string txtTitle)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string cmd = "insert into TBL_CollageMedia values('" + txtTitle + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/Gallery/" + file.FileName));
                    ViewBag.result = "Collage Media And Image Saved Successfully";
                }
                else
                    ViewBag.result = "Collage Media And Image have Not been Saved";
            }
            else
            {
                string img = "";
                string cmd = "insert into TBL_CollageMedia values('" + txtTitle + "','" + img + "','" + DateTime.Now.ToString() + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    ViewBag.result = "Collage Media Saved Successfully";
                }
                else
                    ViewBag.result = "Collage Media has Not been Saved";
            }
            return View();
        }

        public ActionResult NewsEvents()
        {
            ViewBag.result = "";
            return View();
        }

        [HttpPost]
        public ActionResult NewsEvents( string txtTitle)
        {
            HttpPostedFileBase file = Request.Files["txtfile"];

            if (file.FileName != "")
            {
                string cmd = "insert into TBL_NewsEvent values('" + txtTitle + "','" + file.FileName + "','" + DateTime.Now.ToString() + "')";
                bool x = cm.ExecuteInsertUpdateOrDelete(cmd);
                if (x == true)
                {
                    file.SaveAs(Server.MapPath("../Content/Gallery/" + file.FileName));
                    ViewBag.result = "News And Events  Image Saved Successfully";
                }
                else
                    ViewBag.result = "News And Events  Image have Not been Saved";
            }
            else
            {
                string img = "";
                string cmd = "insert into TBL_NewsEvent values('" + txtTitle + "','" + img + "','" + DateTime.Now.ToString() + "')";
                if (cm.ExecuteInsertUpdateOrDelete(cmd) == true)
                {
                    ViewBag.result = "News And Events Saved Successfully";
                }
                else
                    ViewBag.result = "News And Events has Not been Saved";
            }
            return View();
        }
    }
}
