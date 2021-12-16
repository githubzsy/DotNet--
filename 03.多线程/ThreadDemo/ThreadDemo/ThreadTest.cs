/*
 *┌──────────────────────────────────────────┐
 *│  描   述: ThreadTest
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/16 9:55:49
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
    internal static class ThreadTest
    {
        internal static void Test()
        {
            Thread feedChickenCornThread = new Thread(new ThreadStart(FeedChickenCorn));
            feedChickenCornThread.Start();


            Thread feedCatThread = new Thread(new ThreadStart(FeedCat));
            feedCatThread.Start();


            Thread pickEggThread = new Thread(new ThreadStart(PickEgg));
            pickEggThread.Start();

            feedChickenCornThread.Join();
            Thread feedChickenVegetableThread = new Thread(new ThreadStart(FeedChickenVegetable));
            feedChickenVegetableThread.Start();

            pickEggThread.Join();
            Thread wateringVegetableThread = new Thread(new ThreadStart(WateringVegetable));
            wateringVegetableThread.Start();
            Console.ReadKey();
        }

        static void FeedChickenCorn()
        {
            Console.WriteLine("鸡吃玉米开始");
            Thread.Sleep(1000);
            Console.WriteLine("鸡吃玉米，花费10分钟吃完了，可以喂鸡蔬菜了");
        }


        static void FeedChickenVegetable()
        {
            Console.WriteLine("鸡吃蔬菜开始");
            Thread.Sleep(500);
            Console.WriteLine("鸡吃蔬菜，花费5分钟吃完了");
        }

        static void PickEgg()
        {
            Console.WriteLine("人捡鸡蛋开始");
            Thread.Sleep(500);
            Console.WriteLine("人捡鸡蛋，花费5分钟捡完了");
        }

        static void FeedCat()
        {
            Console.WriteLine("猫吃鱼开始");
            Thread.Sleep(500);
            Console.WriteLine("猫吃鱼，花费5分钟吃完了");
        }


        static void WateringVegetable()
        {
            Console.WriteLine("人给蔬菜浇水开始");
            Thread.Sleep(3000);
            Console.WriteLine("人给蔬菜浇水，花费30分钟吃完了");
        }
    }
}
