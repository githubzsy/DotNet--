/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Vegetable
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 19:57:54
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
    internal class Vegetable<T>
    {
        public T Color { get; set; }
    }
}
