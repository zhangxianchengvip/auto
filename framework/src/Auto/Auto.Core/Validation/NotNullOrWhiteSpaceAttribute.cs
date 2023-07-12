using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class NotNullOrWhiteSpaceAttribute : ParameterInterceptorAttribute
    {
        private readonly string _message;

        public NotNullOrWhiteSpaceAttribute(string message = "")
        {
            _message = message;
        }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            context.Parameter.Value.CheckNotNull
            (
                param: context.Parameter.Name,
                message: _message
            ).CheckConvertType<string>
            (
                param: context.Parameter.Name,
                message: _message
            ).CheckIsNullOrWhiteSpace
            (
                param: context.Parameter.Name,
                message: _message
            );

            return next(context);
        }
    }
}