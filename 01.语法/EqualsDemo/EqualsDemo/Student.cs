/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Student
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 19:32:59
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
    internal class Student : IHasNo, IHasNo2
    {
        public int Id { get; set; }

        public string GetNo()
        {
            return "202111212";
        }

        public string GetNo(string no)
        {
            return no;
        }
    }
}
