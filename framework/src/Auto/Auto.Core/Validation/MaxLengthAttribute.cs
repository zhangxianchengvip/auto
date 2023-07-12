using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class MaxLengthAttribute : ParameterInterceptorAttribute
    {
        private readonly int _maxLength;
        private readonly string? _message;

        public MaxLengthAttribute(int maxLength = int.MaxValue, string? message = null)
        {
            _maxLength = maxLength;
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
            ).CheckStringMaxLength
            (
                maxLength: _maxLength,
                param: nameof(context.Parameter.Name),
                message: _message
            );


            return next(context);
        }
    }
}