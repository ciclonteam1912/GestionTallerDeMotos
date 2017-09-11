using System;
using System.Web.Mvc;

namespace GestionTallerDeMotos.Models.AtributosDeAutorizacion
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AutorizacionPersonalizada : AuthorizeAttribute
    {
        private const string IS_AUTHORIZED = "isAuthorized";

        public string RedirectUrl = "~/home/index";

        public AutorizacionPersonalizada(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            bool isAuthorized = base.AuthorizeCore(httpContext);

            httpContext.Items.Add(IS_AUTHORIZED, isAuthorized);

            return isAuthorized;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var isAuthorized = filterContext.HttpContext.Items[IS_AUTHORIZED] != null
                ? Convert.ToBoolean(filterContext.HttpContext.Items[IS_AUTHORIZED])
                : false;

            if (!isAuthorized && filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect(RedirectUrl);
            }
        }
    }
}