using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using System;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class NotNullOrEmptyAttribute : ParameterInterceptorAttribute
    {
        private readonly string _message;

        public NotNullOrEmptyAttribute(string message = "")
        {
            _message = message;
        }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            context.Parameter.Value.CheckNotNull
            (
                param: nameof(context.Parameter.Name),
                message: _message
            ).CheckConvertType<string>
            (
                param: nameof(context.Parameter.Name),
                message: _message
            ).CheckStringEmpty
            (
                param: nameof(context.Parameter.Name),
                message: _message
            );


            return next(context);
        }
    }
}