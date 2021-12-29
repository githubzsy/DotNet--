/*
 *┌──────────────────────────────────────────┐
 *│  描   述: PersiaCat
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 17:07:58
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
    internal class PersiaCat:Cat
    {
        public override string ToString()
        {
            return "波斯猫:" + Name;
        }
    }
}
