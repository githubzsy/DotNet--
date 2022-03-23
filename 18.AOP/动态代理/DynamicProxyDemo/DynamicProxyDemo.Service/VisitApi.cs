namespace DynamicProxyDemo.Service
{
    /// <summary>
    /// 假定实际业务是访问Api
    /// </summary>
    public class VisitApi : IVisitApi
    {
        public virtual void Visit(string api)
        {
            Console.WriteLine("访问了Api:" + api);
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface IVisitApi
    {
        void Visit(string api);

        void SayHello();
    }
}
