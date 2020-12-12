using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependecyResolvers.Ninject3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DevFramework.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControlerFactory(new BusinessModule()));
        }

        /*asp.net MVCde kullanıcının identity bilgilerine erişilebilir olduğu zaman (get set olayı olduğunda) 
         * bu yüzden post authenticate Request eventine hanle( eldengeçirmek, işlemek) edillecek.*/

        public override void Init()
        {
            //kişinin authenticasyon bilgileri erişilebilir olduğunda.
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookei = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookei == null)
                {
                    return;
                }

                var encTicket = authCookei.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                //mvcde erişm için:
                HttpContext.Current.User = principal;
                //bussinesta erişim için:
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {
            }
           
        }
    }
}
