using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Ascpects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType { get; set; }

        private LoggerService _loggerService;

        public LogAspect( Type loggerType)
        {
            _loggerType = loggerType;
        }
        //çalışmaya başladığında
        public override void RuntimeInitialize(MethodBase method)
        { 
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }
        //methoda girildiğinde
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }
            //t= gelen tip
            //i ise .0 argüman,1 argüman ....
            var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
            {
                Name = t.Name,
                Type = t.ParameterType.Name,
                Value = args.Arguments.GetArgument(i)
            }).ToList();

            var logDetail = new LogDetail
            {
                FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                MethodName = args.Method.Name,
                Parameters = logParameters
            };

            _loggerService.info(logDetail);
        }
    }
}
