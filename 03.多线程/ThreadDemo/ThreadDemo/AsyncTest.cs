/*
 *┌──────────────────────────────────────────┐
 *│  描   述: AsyncTest
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/16 9:57:35
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    internal class AsyncTest
    {
        internal async static void Test()
        {
            var task = FeedChickenCorn();
            FeedCat();
            PickEgg();

            var a= await task;
            FeedChickenVegetable();

            await PickEgg();
            WateringVegetable();
        }

        static async Task<string> FeedChickenCorn()
        {
             Console.WriteLine("鸡吃玉米开始, 当前线程为:"+ Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
           
            Console.WriteLine("鸡吃玉米，花费10分钟吃完了，可以喂鸡蔬菜了, 当前线程为:"+Thread.CurrentThread.ManagedThreadId);
            return "abc";
        }


        static async Task FeedChickenVegetable()
        {
            Console.WriteLine("鸡吃蔬菜开始");
            await Task.Delay(500);
            Console.WriteLine("鸡吃蔬菜，花费5分钟吃完了");
        }

        static async Task PickEgg()
        {
            Console.WriteLine("人捡鸡蛋开始");
            await Task.Delay(500);
            Console.WriteLine("人捡鸡蛋，花费5分钟捡完了");
        }

        static async Task FeedCat()
        {
            Console.WriteLine("猫吃鱼开始");
            await Task.Delay(500);
            Console.WriteLine("猫吃鱼，花费5分钟吃完了");
        }


        static async Task WateringVegetable()
        {
            Console.WriteLine("人给蔬菜浇水开始");
            await Task.Delay(3000);
            Console.WriteLine("人给蔬菜浇水，花费30分钟吃完了");
        }
    }
}
