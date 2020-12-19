using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Commen
{
    public class WcfProxy<T> 
    {
        //http://localhost:58947/{0}.svc buna yol veriyoruz.
        //T = IPorductService(wcf service içerisindeki)
        public static T CreateChannel()
        {
            string baseAddress = ConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress,typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<T>(binding, address);

            return channel.CreateChannel();
        }
    }
}
