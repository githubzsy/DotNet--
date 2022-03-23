using DynamicProxyDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyDemo
{
    public class ChildVisitApi:VisitApi
    {
        public override void Visit(string api)
        {
            Console.WriteLine("执行之前");
            base.Visit(api);
        }
    }
}
