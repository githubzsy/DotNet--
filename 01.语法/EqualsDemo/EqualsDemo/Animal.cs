/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Animal
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 18:35:08
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
    public abstract class Animal
    {
        public abstract int Age { get; set; }

        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract void Eat();
    }
}
