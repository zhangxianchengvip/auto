using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class MinLengthAttribute : ParameterInterceptorAttribute
    {
        private readonly int _minLength;
        private readonly string? _message;

        public MinLengthAttribute(int minLength = int.MinValue, string? message =null)
        {
            _minLength = minLength;
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
            ).CheckStringMinLength
            (
                minLength: _minLength,
                param: nameof(context.Parameter.Name),
                message: _message
            );

            return next(context);
        }
    }
}