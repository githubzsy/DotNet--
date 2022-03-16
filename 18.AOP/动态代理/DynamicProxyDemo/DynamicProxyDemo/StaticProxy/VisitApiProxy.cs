using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyDemo.StaticProxy
{
    /// <summary>
    /// 访问Api代理类
    /// </summary>
    public class VisitApiProxy : VisitApi
    {
        public override void Visit(string api)
        {
            Console.WriteLine("开始访问");
            base.Visit(api);
            Console.WriteLine("结束访问");
        }
    }
}
