using System;

namespace Auto.Core.Validation
{
    public static class AutoValidationExtension
    {
        public static object CheckNotNull(this object obj, string param, string? message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException
                (
                    paramName: param,
                    message: message ?? $"{param} is null!"
                );
            }

            return obj;
        }

        public static string CheckStringMaxLength(this string str, int maxLength, string param, string? message = null)
        {
            var length = str.Length;

            if (length > maxLength)
            {
                throw new ArgumentException
                (
                    paramName: param,
                    message: message ?? $"{param} Length out of  range!"
                );
            }

            return str;
        }

        public static string CheckStringMinLength(this string str, int minLength, string param, string? message = null)
        {
            var length = str.Length;

            if (length < minLength)
            {
                throw new ArgumentException
                (
                    paramName: param,
                    message: message ?? $"{param} Length out of  range!"
                );
            }

            return str;
        }

        public static string CheckIsNullOrWhiteSpace(this string str, string param, string? message = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException
                (
                    paramName: param,
                    message: message ?? $"{param} is Null Or WhiteSpace!"
                );
            }

            return str;
        }

        public static T CheckConvertType<T>(this object obj, string param, string? message = null)
        {
            if (!(obj is T value))
            {
                throw new ArgumentException
                (
                    paramName: param,
                    message: $"{param} must is {typeof(T)}!"
                );
            }

            return value;
        }

        public static object CheckRange(this object obj, double max, double min, string param, string? message = null)
        {
            var type = obj is short || obj is int || obj is float || obj is double || obj is long;

            if (!type)
            {
                throw new ArgumentException
                (
                    paramName: param,
                    message: $"{param} must is number!"
                );
            }

            double.TryParse((string)obj, out var value);

            if (value > max || value < min)
            {
                throw new ArgumentOutOfRangeException
                (
                    paramName: param,
                    message: $"{param} out of  range!"
                );
            }

            return obj;
        }

        public static string CheckStringLength(this string str, int max, int min, string param, string? message = null)
        {
            var length = str.Length;

            if (length < min || length > max)
            {
                throw new ArgumentOutOfRangeException
                (
                    message: message,
                    paramName: $"{param} Length out of range!"
                );
            }

            return str;
        }


        public static string CheckStringEmpty(this string str, string param, string? message = null)
        {
            if (str == string.Empty)
            {
                throw new ArgumentNullException
                (
                    paramName: param,
                    message: message
                );
            }

            return str;
        }
    }
}