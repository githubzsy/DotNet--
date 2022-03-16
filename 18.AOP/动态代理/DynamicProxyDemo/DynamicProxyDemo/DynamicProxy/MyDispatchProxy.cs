using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyDemo.DynamicProxy
{
    /// <summary>
    /// 动态代理类
    /// </summary>
    public class MyDispatchProxy:DispatchProxy
    {
        /// <summary>
        /// 被代理的实例
        /// </summary>
        public object Instance { get; set; }

        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <returns></returns>
        public Action<object, MethodInfo, object[]> BeforeInvoke { get; set; } = null;

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <returns></returns>
        public Action<object, MethodInfo, object[], object> AfterInvoke { get; set; } = null;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            BeforeInvoke?.Invoke(Instance, targetMethod, args);
            var obj = targetMethod?.Invoke(Instance, args);

            AfterInvoke?.Invoke(Instance, targetMethod, args, obj);
            return obj;
        }
    }
}
