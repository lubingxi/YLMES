using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult UploadDrawings(string DrawingNo, HttpPostedFileBase files)
        {
            return Content("");
        }
        #endregion
    }
}