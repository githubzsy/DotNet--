/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Hashiqi
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 18:52:18
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
    public partial class Hashiqi:Dog
    {
        public int Length { get; set; }

        public override string Food { get; set; }

        public void Test<T>(T t) where T : class
        {
            Console.WriteLine(t);
        }

        /// <summary>
        /// 运算符重载
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Hashiqi operator +(Hashiqi b, Hashiqi c)
        {
            Hashiqi a = new Hashiqi();
            a.Length = b.Length + c.Length;
            return a;
        }



        private string No { get; set; }
    }
}
