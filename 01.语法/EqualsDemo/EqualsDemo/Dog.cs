/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Dog
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 18:36:09
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
    public class Dog : Animal
    {
        public static bool HasTail =>true;

        /// <summary>
        /// 属性
        /// </summary>
        internal string Name => "铁头";

        public override int Age { get; set; }

        

        /// <summary>
        /// 字段
        /// </summary>
        protected readonly string Pinzhong = "金毛";

        /// <summary>
        /// 虚属性
        /// </summary>
        public virtual string Food { get; set; } = "狗粮";

        public override void Eat()
        {
            Console.WriteLine("狗吃"+Food);
        }

        /// <summary>
        /// 虚方法
        /// </summary>
        public virtual void Drink()
        {
            Console.WriteLine("狗喝水");
        }


    }
}
