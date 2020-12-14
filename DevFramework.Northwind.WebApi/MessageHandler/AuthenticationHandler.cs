using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependecyResolvers.Ninject3;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace DevFramework.Northwind.WebApi.MessageHandler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        //Token yakalamaya çalışılcak

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Autherization").FirstOrDefault();
                if (token != null)
                {
                    //token boş değilse çözümle
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':'); // (nurcöer:12345)

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);

                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]),
                            userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}