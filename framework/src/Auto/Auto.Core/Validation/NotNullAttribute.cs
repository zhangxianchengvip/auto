using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class NotNullAttribute : ParameterInterceptorAttribute
    {
        private readonly string _message;

        public NotNullAttribute(string message = "")
        {
            _message = message;
        }


        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            context.Parameter.Value.CheckNotNull
            (
                param: nameof(context.Parameter.Name),
                message: _message
            );

            return next(context);
        }
    }
}