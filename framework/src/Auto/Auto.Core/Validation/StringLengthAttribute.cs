using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class StringLengthAttribute : ParameterInterceptorAttribute
    {
        private readonly string? _message;
        private readonly int _maxLength;
        private readonly int _minLength;

        public StringLengthAttribute(int maxLength, int minLength = 0, string? message = null)
        {
            _message = message;
            _maxLength = maxLength;
            _minLength = minLength;
        }


        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            context.Parameter.Value.CheckNotNull
            (
                param: nameof(context.Parameter.Value),
                message: _message
            ).CheckConvertType<string>
            (
                param: nameof(context.Parameter.Value),
                message: _message
            ).CheckStringLength
            (
                max: _maxLength,
                min: _minLength,
                param: nameof(context.Parameter.Value),
                message: _message
            );


            return next(context);
        }
    }
}