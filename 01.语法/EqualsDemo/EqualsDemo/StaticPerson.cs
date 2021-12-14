/*
 *┌──────────────────────────────────────────┐
 *│  描   述: StaticPerson
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 19:25:13
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    /// <summary>
    /// 静态类
    /// </summary>
    public static class StaticPerson
    {
        /// <summary>
        /// 名称
        /// </summary>
        public static string Name { get; set; }

        public static void Eat()
        {
            Console.WriteLine("静态人吃饭");
        }
    }
}
