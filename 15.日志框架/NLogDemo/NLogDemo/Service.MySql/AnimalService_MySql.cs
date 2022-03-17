using IService;
using System;

namespace Service.MySql
{
    /// <summary>
    /// 对oracle数据库操作
    /// </summary>
    public class AnimalService_MySql : IAnimalService
    {
        public void Add(string animal)
        {
            Console.WriteLine("MySql_" + animal);
        }
    }
}
