using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}