// See https://aka.ms/new-console-template for more information
using DynamicProxyDemo;
using DynamicProxyDemo.DynamicProxy;
using DynamicProxyDemo.StaticProxy;

#region 静态代理
//IVisitApi visitApi = GetInstanceFromStaticProxy();
//visitApi.Visit("你好API");
#endregion

#region 容器
MyContainer container = new MyContainer();
container.Register<IVisitApi, VisitApi>();
container.RegisterAop<VisitApi>((instance, method, args) =>
{
    Console.WriteLine($"调用了方法:{method.Name},参数:{args}");
}, null);
IVisitApi visitApi = GetInstanceFromMyContainer<IVisitApi>();
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