/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Cat
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 16:02:52
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarianceDemo
{
    internal class Cat:Animal
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "Cat Name:" + Name;
        }
    }
}
