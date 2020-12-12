using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Ascpects.Postsharp.Exceptionaspects
{
    [Serializable]
    public class ExceptionLogAspect : OnExceptionAspect
    {
        
        private Type _loggerType { get; set; }

        private LoggerService _loggerService;

        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        //çalışmaya başladığında
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType != null)
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                {
                    throw new Exception("Wrong Logger Type");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
            base.RuntimeInitialize(method);
        }
        //methoda girildiğinde
        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService != null)
            {
                _loggerService.Error(args.Exception);
            }

        }
    }
}
