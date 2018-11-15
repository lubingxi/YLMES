using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YLMES.Controllers
{
    public class PurchasingManageController : Controller
    {
        // GET: PurchasingManage
        public ActionResult Index()
        {
            return View();
        }
        #region 采购信息
        //采购信息页面
        public ActionResult SupplierInformation()
        {
            return View();
        }
        //显示采购信息
        //public ActionResult CheckSupplierInformation()
        //{

        //}
        #endregion
    }
}