using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =true)]
    public class MyAttribute:Attribute
    {
        public MyAttribute()
        {
        }

        public MyAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
