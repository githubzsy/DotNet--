/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Person
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 18:24:10
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
    public class Person :Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Eat()
        {
            Console.WriteLine("人吃狗");
        }
    }
}
