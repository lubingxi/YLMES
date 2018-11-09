using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YLMES.Models;

namespace YLMES.Controllers
{
    public class SystemSettingsController : Controller
    {
        // GET: SystemSettings
        public ActionResult Index()
        {
            return View();
        }

        #region 权限设置

        public ActionResult Permissions()
        {
            return View();
        }

        #endregion

        #region 系统权限工艺BOM
        public ActionResult Process()
        {
            return View();
        }
        //显示工艺BOM信息
        public ActionResult CheckProcessBOM(string Name, string PartSpec, string Material,int page,int limit)
        {
            using (YLMES_newEntities ys = new YLMES_newEntities())
            {
                SqlParameter[] parms = new SqlParameter[3];
                parms[0] = new SqlParameter("@PartNumber", Name);
                parms[1] = new SqlParameter("@PartSpec", PartSpec);
                parms[2] = new SqlParameter("@PartMaterial", Material);
                var list = ys.Database.SqlQuery<ProcessBOM_Result>("exec ProcessBOM @PartNumber,@PartSpec,@PartMaterial", parms).ToList();
                Dictionary<string, Object> hasmap = new Dictionary<string, Object>();
                PageList<ProcessBOM_Result> pageList = new PageList<ProcessBOM_Result>(list, page, limit);
                int count = list.Count();
                hasmap.Add("code", 0);
                hasmap.Add("msg", "");
                hasmap.Add("count", count);
                hasmap.Add("data", pageList);
                return Json(hasmap, JsonRequestBehavior.AllowGet);
            }
        }
        //导入EXCEL
        //public ActionResult StationImport(HttpPostedFileBase files)
        //{
        //    try
        //    {

        //        return Content("true");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return Content("false");
        //    }

        //}
        //删除BOM
        public ActionResult DeleteProcessBOM(string id)
        {
            try
            {
                int tid = int.Parse(id);
                SqlParameter[] parms = new SqlParameter[2];
                parms[0] = new SqlParameter("@ID", tid);
                parms[1] = new SqlParameter("@PartNumber", "");
                using (YLMES_newEntities ys = new YLMES_newEntities())
                {
                    ys.Database.ExecuteSqlCommand("exec  DeleteProcessBOM  @ID,@PartNumber", parms);
                }
                return Content("true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("false");
            }
        }
        //修改BOM
        public ActionResult EditProcessBOM(string id, string pc, string ph)
        {
            try
            {
                int tid = int.Parse(id);
                SqlParameter[] parms = new SqlParameter[4];
                parms[0] = new SqlParameter("@ID", tid);
                parms[1] = new SqlParameter("@PartNumber", "");
                parms[2] = new SqlParameter("@ChildPartQTY", pc);
                parms[3] = new SqlParameter("@ChildPartNumber", ph);
                using (YLMES_newEntities ys = new YLMES_newEntities())
                {
                    ys.Database.ExecuteSqlCommand("exec  EditProcessBOM  @ID,@PartNumber,@ChildPartQTY,@ChildPartNumber", parms);
                }
                return Content("true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("false");
            }
        }
        //添加子件
        public ActionResult AddProcessBOM(string name, string PartSpec)
        {
            try
            {
                string username = Session["name"].ToString();
                SqlParameter[] parms = new SqlParameter[3];
                parms[0] = new SqlParameter("@PartNumber", name);
                parms[1] = new SqlParameter("@PartSpec", PartSpec);
                parms[2] = new SqlParameter("@CreatedBy", username);
                using (YLMES_newEntities ys = new YLMES_newEntities())
                {
                    ys.Database.ExecuteSqlCommand("exec  AddProcessBOM  @PartNumber,@PartSpec,@CreatedBy", parms);
                }
                return Content("true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("false");
            }
        }
        //显示子件
        public ActionResult BOM2(string name)
        {
            ViewData["name"] = name;
            return View();
        }
        #endregion

        #region 库区

        public ActionResult Reservoir()
        {
            return View();
        }
        //显示库区信息
        public ActionResult CheckReservoir(string select, string Reservoir)
        {
            using (YLMES_newEntities ys = new YLMES_newEntities())
            {
                SqlParameter[] parms = new SqlParameter[2];
                string name = Session["name"].ToString();
                parms[0] = new SqlParameter("@Owner", name);
                parms[1] = new SqlParameter("@Status", Status);
                var list = ys.Database.SqlQuery<MyTaskCheck_Result>("exec MyTaskCheck @Owner,@Status", parms).ToList();
                Dictionary<string, Object> hasmap = new Dictionary<string, Object>();
                PageList<MyTaskCheck_Result> pageList = new PageList<MyTaskCheck_Result>(list, page, limit);
                int count = list.Count();
                hasmap.Add("code", 0);
                hasmap.Add("msg", "");
                hasmap.Add("count", count);
                hasmap.Add("data", pageList);
                return Json(hasmap, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 库位

        public ActionResult Location()
        {
            return View();
        }

        #endregion

        #region 货位

        public ActionResult Goods()
        {
            return View();
        }

        #endregion
    }
}