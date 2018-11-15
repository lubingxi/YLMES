using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YLMES.Models;

namespace YLMES.Controllers
{
    public class TechnicalDepartmentController : Controller
    {
        // GET: TechnicalDepartment
        public ActionResult Index()
        {
            return View();
        }

        #region  技术部
        //图纸页面
        public ActionResult UploadTheDrawings()
        {
            return View();
        }
        //上传图纸
        [HttpPost]
        public ActionResult UploadDrawings(string hao,HttpPostedFileBase files)
        {
            try
            {
                if (hao == "")
                {
                    return Content("<script>alert('图号不能为空');history.go(-1);</script>");
                }
                else
                {
                    var fileName1 = Path.Combine(Request.MapPath("~/Upload"), Path.GetFileName(files.FileName));
                    files.SaveAs(fileName1);
                    string fname = fileName1.Substring(fileName1.LastIndexOf('\\') + 1);
                    using (YLMES_newEntities ys = new YLMES_newEntities())
                    {
                        string name = Session["name"].ToString();
                        SqlParameter[] parms = new SqlParameter[4];
                        parms[0] = new SqlParameter("@FigureNumber", hao);
                        parms[1] = new SqlParameter("@FolderName", "Upload");
                        parms[2] = new SqlParameter("@FileName", fname);
                        parms[3] = new SqlParameter("@CreatedBy", name);
                        ys.Database.ExecuteSqlCommand("exec UploadTheDrawings  @FigureNumber,@FolderName,@FileName,@CreatedBy", parms);
                    }
                    return Content("<script>alert('上传成功！');history.go(-1);</script>");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Content("<script>alert('出现异常');history.go(-1);</script>");
            }
          

        }
        #endregion
    }
}