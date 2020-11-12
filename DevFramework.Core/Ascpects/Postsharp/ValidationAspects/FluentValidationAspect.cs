using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Linq;

namespace DevFramework.Core.Ascpects.Postsharp
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            

            foreach (var  entity in entities)
            {
                //object bir nesneyi IValidationContext Türüne çevirmek için ValidationContext Generic Sınıfı kullanıldı.
                var context = new ValidationContext<object>(entity);

                ValidatorTool.FluentValidate(validator, context);
            }
        }
    }
}
