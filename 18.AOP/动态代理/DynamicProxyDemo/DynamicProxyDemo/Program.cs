// See https://aka.ms/new-console-template for more information
using DynamicProxyDemo;
using DynamicProxyDemo.DynamicProxy;
using DynamicProxyDemo.Service;
using DynamicProxyDemo.StaticProxy;

#region 静态代理
//IVisitApi visitApi = GetInstanceFromStaticProxy();
//visitApi.Visit("你好API");
#endregion

#region 容器
MyContainer container = new MyContainer();
// 注册VisitApi
container.Register<IVisitApi, VisitApi>();

// 注册IVisitApi
//container.Register<IVisitApi, ChildVisitApi>();

// 注册AOP, 在VisitApi任何方法调用之前都先 输出....
container.RegisterAop<VisitApi>((instance, method, args) =>
{
    Console.WriteLine($"调用了方法:{method.Name},参数:{args}");
}, null);


// 业务代码
// 目标: SayHello之前记录日志
new VisitApi().SayHello();


IVisitApi visitApi = GetInstanceFromMyContainer<IVisitApi>();
// proxy.Visit() => {BeforeInvoke(); new VisitApi().Visit(); AfterInvoke();}
visitApi.Visit("你好API");
visitApi.SayHello();
#endregion


Console.ReadKey();

/// <summary>
/// 从容器中获取实例或者代理类
/// </summary>
static VisitApi GetInstanceFromStaticProxy()
{
    return new VisitApiProxy();
}

T GetInstanceFromMyContainer<T>()
{
     return container.Get<T>();
}