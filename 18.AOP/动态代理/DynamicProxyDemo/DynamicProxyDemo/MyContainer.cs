using DynamicProxyDemo.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyDemo
{
    public class MyContainer
    {
        readonly Dictionary<Type,Type> _types = new ();
        readonly Dictionary<Type, (Action<object, MethodInfo, object[]> beforeInvoke, Action<object, MethodInfo, object[], object> afterInvoke)> _actions = new();

        public void Register<TInterface, TImplement>() where TImplement:class ,TInterface, new()
        {
            _types.Add(typeof(TInterface), typeof(TImplement));
        }

        /// <summary>
        /// 对实体类中的方法注册切面
        /// </summary>
        /// <typeparam name="TImplement">实体类类型</typeparam>
        /// <param name="beforeInvoke">方法执行前动作</param>
        /// <param name="afterInvoke">方法执行后动作</param>
        public void RegisterAop<TImplement>(Action<object, MethodInfo, object[]> beforeInvoke, Action<object, MethodInfo, object[], object> afterInvoke) where TImplement:class
        {
            _actions.Add(typeof(TImplement), (beforeInvoke, afterInvoke));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInterface">被代理的接口</typeparam>
        /// <returns></returns>
        public TInterface Get<TInterface>()
        {
            var implement = _types[typeof(TInterface)];
            if(_actions.TryGetValue(implement, out var actions) && actions.afterInvoke!=null || actions.beforeInvoke!=null)
            {
                // 生成代理类
                // IVisitApi
                // ChildDispatchProxy : MyDispatchProxy, IVisitApi
                // proxy = new ChildDispatchProxy()
                var proxy = DispatchProxy.Create<TInterface, MyDispatchProxy>();

                var myProxy = proxy as MyDispatchProxy;

                // Assembly.GetAssembly(implement)?.CreateInstance(implement.FullName) 找到 IVisitApi对应的实现类 VisitApi，创建其实例 new VisitApi
                // proxy.Instance =(TInterface)(new VisitApi());
                myProxy.Instance = (TInterface)Assembly.GetAssembly(implement)?.CreateInstance(implement.FullName);
                myProxy.BeforeInvoke = actions.beforeInvoke;
                myProxy.AfterInvoke = actions.afterInvoke;
                // IVisitApi
                return proxy;
            }
            else
            {
                // 构造函数的选择: https://www.codenong.com/32931716/
                // 默认选择第一个具有已知参数的构造函数
                // 生成实体类
                return (TInterface)Assembly.GetAssembly(implement)?.CreateInstance(implement.FullName);
            }
           
        }
    }
}
