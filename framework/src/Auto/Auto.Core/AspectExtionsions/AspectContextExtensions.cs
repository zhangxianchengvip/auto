using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Core.AspectExtionsions
{
    /// <summary>
    /// Aspect 扩展
    /// </summary>
    public static class AspectContextExtensions
    {
        /// <summary>
        /// 获取参数字典
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetParamsDictionary(this AspectContext context)
        {
            //得到方法的参数
            var pars = context.ProxyMethod.GetParameters();

            //设置参数名和值 加入字典
            var dicValue = new Dictionary<string, object>();
            for (var i = 0; i < pars.Length; i++)
            {
                dicValue.Add(pars[i].Name, context.Parameters[i]);
            }
            return dicValue;
        }

        /// <summary>
        /// 获取默认Key值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetDefaultKey(this AspectContext context)
        {
            return $"{context.ServiceMethod.DeclaringType}.{context.ImplementationMethod.Name}:{context.ServiceMethod.ToString()}";
        }

        public static string GetCacheKey(this AspectContext context)
        {
            var methodName = context.ImplementationMethod.DeclaringType + $".{context.ImplementationMethod.Name}";
            var sb = new StringBuilder();
            //foreach (var item in context.ServiceMethod.GetParameters())
            //{
            //    sb.Append($".{item.Name}");
            //}
            foreach (var value in context.Parameters)
            {
                sb.Append($"({value})");
            }
            //foreach (var value in context.Parameters)
            //{
            //    sb.Append($":HashCode({value.GetHashCode()})");
            //}
            return methodName + sb.ToString();
        }

        /// <summary>
        /// 获取返回值类型
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Type GetReturnType(this AspectContext context)
        {
            return context.IsAsync()
                ? context.ServiceMethod.ReturnType.GetGenericArguments().First()
                : context.ServiceMethod.ReturnType;
        }

        /// <summary>
        /// 获取返回值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<object> GetReturnValue(this AspectContext context)
        {
            return context.IsAsync() ? await context.UnwrapAsyncReturnValue() : context.ReturnValue;
        }
    }
}
