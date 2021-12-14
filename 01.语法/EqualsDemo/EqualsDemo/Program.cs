using System;
using System.Collections.Generic;

namespace EqualsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man();
            man.Id = 1;

            //Dog dog = new Dog();
            //Console.WriteLine(dog.Name);
            //dog.Name = "";
            //dog.Pinzhong = "123";

            //Jinmao jinmao = new Jinmao();
            //DogDrink(jinmao);

            //Dog hashiqi = new Hashiqi();
            //DogDrink(hashiqi);
            // DogEatTest();
            //StaticPerson.Name = "静态人";
            //StaticPerson.Eat();
            //Console.WriteLine(Dog.HasTail);

            //Student student = new Student();

            //InterfaceTest(student);

            //Vegetable<string> tomato = new Vegetable<string>();

            //Vegetable<int> apple =new Vegetable<int>();


            //List<int> lst=new List<int>();
            //List<string> lst2=new List<string>();

            //AddOverrideTest();

            var a = new { X = 1, Y = "abc" };
            var b = new { Z = 1 };
            TestAnymouse(a);
            Console.ReadKey();
        }

        static void TestAnymouse(dynamic a)
        {
            Console.WriteLine(a.X);
        }

        static void AddOverrideTest()
        {
            Hashiqi a = new Hashiqi();
            a.Test(a);
            a.Length = 1;
            Hashiqi b =new Hashiqi();
            b.Length = 2;
            Console.WriteLine((a + b).Length);
        }

        static void InterfaceTest(IHasNo hasNo)
        {
            Console.WriteLine(hasNo.GetNo());
        }

        static void DogEatTest()
        {
            Hashiqi hashiqi = new Hashiqi();
            hashiqi.Food = "人";
            
            AnimalEat(hashiqi);

            Jinmao jinmao =new Jinmao();
            AnimalEat(jinmao);
        }

        static void AnimalEatTest()
        {
            Dog dog = new Dog();
            AnimalEat(dog);

            Person person = new Person();
            AnimalEat(person);
        }

        static void AnimalEat(Animal animal)
        {
            animal.Eat();
        }

        static void DogDrink(Dog dog)
        {
            dog.Drink();
        }

        static void DogPlay(Dog dog)
        {
            Console.WriteLine(dog.Name + "在玩耍");
        }

        static void AnoTest()
        {

            var a = new { X = 2 };
            var b = new { X = 1 };
            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
        }

        static void ClassTest()
        {
            Person a = new Person { Id = 1 };
            Person b = new Person { Id = 1 };

            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a == b);
        }


        static void StringTest()
        {
            string a = "abc";
            string b = "abc";

            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a == b);
        }
    }
}
