using AspectCore.DynamicProxy.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.Validation
{
    public class RangeAttribute : ParameterInterceptorAttribute
    {
        private readonly double _min;
        private readonly double _max;
        private readonly string? _message;


        public RangeAttribute(short min, short max, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message;
        }

        public RangeAttribute(int min, int max, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message;
        }

        public RangeAttribute(double min, double max, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message;
        }

        public RangeAttribute(float min, float max, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message;
        }

        public RangeAttribute(long min, long max, string? message = null)
        {
            _min = min;
            _max = max;
            _message = message;
        }

        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            context.Parameter.Value.CheckNotNull
            (
                param: nameof(context.Parameter.Name),
                message: _message
            ).CheckRange
            (
                max: _max,
                min: _min,
                param: nameof(context.Parameter.Value),
                message: _message
            );

            return next(context);
        }
    }
}