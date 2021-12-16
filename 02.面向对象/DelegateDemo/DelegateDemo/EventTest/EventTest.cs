/*
 *┌──────────────────────────────────────────┐
 *│  描   述: EventTest
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/16 10:28:04
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo.EventTest
{
    public static class EventTest
    {
        internal static void Test1()
        {
            var searcher = new FileSearcher();
            searcher.Search("d:\\", "*.cer");
        }

        internal static void Test2()
        {
            var searcher = new FileSearcher();
            // 订阅
            searcher.FileFound += Searcher_FileFound1;
            searcher.Search("d:\\", "*.cer");
        }

        private static void Searcher_FileFound1(object? sender, FileFoundArgs e)
        {
            Console.WriteLine("Searcher_FileFound:" + e.FoundFile);
        }

    }
}
