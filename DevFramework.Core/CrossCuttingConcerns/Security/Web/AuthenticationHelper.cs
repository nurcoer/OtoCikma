using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    //Kullanıcı bilgilerini alıp onları şifreleyip cookei'ye basmak.
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string username, string email, DateTime expiration, string[] roles,
            bool rememberMe, string firstname, string lastname)
        {
            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, rememberMe, 
                CreateAuthTags(email, roles, firstname, lastname, id));

            string encTicked = FormsAuthentication.Encrypt(authTicket);
            //http cookielere ekliyo giriş yapan kişiyi.
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicked));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstname, string lastname, Guid id)
        {
            //stringBuilder (email|admin,editor|firstname|lastname|id)
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i<roles.Length-1)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstname);
            stringBuilder.Append("|");
            stringBuilder.Append(lastname);
            stringBuilder.Append("|");
            stringBuilder.Append(id);

            return stringBuilder.ToString();
        }


    }
}
