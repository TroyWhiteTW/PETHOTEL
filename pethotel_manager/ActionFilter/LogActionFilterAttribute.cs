using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace pethotel_manager.ActionFilter
{
    /// <summary>
    /// 登入狀態判斷
    /// </summary>
    public class LogActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext ctx = HttpContext.Current;

            //未登入導回首頁
            if (string.IsNullOrEmpty(HttpContext.Current.Session["managerid"].ToString()))
            {                
                context.Result = new RedirectResult("~/Home/Index");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}