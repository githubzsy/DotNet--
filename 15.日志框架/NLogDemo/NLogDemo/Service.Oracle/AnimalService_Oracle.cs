using IService;
using System;

namespace Service.Oracle
{
    /// <summary>
    /// 对oracle数据库操作
    /// </summary>
    public class AnimalService_Oracle : IAnimalService
    {
        public void Add(string animal)
        {
            Console.WriteLine("Oracle_" + animal);
        }
    }
}
