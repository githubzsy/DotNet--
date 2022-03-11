// See https://aka.ms/new-console-template for more information
using VarianceDemo;



#region 兼容
// Assignment compatibility.
string str = "test";
// An object of a more derived type is assigned to an object of a less derived type.
// 子类对象赋值给父类变量
object obj = str;
#endregion

#region 协变: 表示类型兼容和 T 的一致

// 举例1:
// Covariance.
IEnumerable<string> strings = new List<string>();
// An object that is instantiated with a more derived type argument
// is assigned to an object instantiated with a less derived type argument.
// Assignment compatibility is preserved.
// 父类可以作为结果传出，相当于IEnumerable中的返回类型为Object，可以接收返回String类型
IEnumerable<object> objects = strings;


IEnumerable<object> objects2 = new List<object>() { "1",1 };
IEnumerable<string> strings2 =  new List<string>();
foreach (var item in objects2)
{
    string s = (string)item;

}
// 举例2:
IEnumerable<Cat> cats=new List<Cat>();
IEnumerable<Animal> animals = cats;

#endregion

#region 逆变: 表示 T 作为参数类型，可以接受其自身和父类
// Contravariance.
// Assume that the following method is in the class:
// static void SetObject(object o) { }
Action<object> actObject = (object t) => {  };
// An object that is instantiated with a less derived type argument
// is assigned to an object instantiated with a more derived type argument.
// Assignment compatibility is reversed.
Action<string> actString = actObject;
actString("123");


Func<string> funcString = () => { return "a"; };
Func<object> funcObject = funcString;
funcObject();
#endregion



// 举例3:
Variance <Cat, Animal, Cat> variance = new();

// 接口类型为Animal，可协变，接收其自身和子类
ICovariance<Animal> covariance = variance;
var animal = covariance.Covariance();

// 接口类型为Cat，可逆变，接收其自身和父类
IContravariance<Cat> contravariance = variance;
contravariance.Contravariance(new Cat { Name = "大黄" });

// 类型为普通类型，接收其本身
IGeneric<Cat> generic = variance;
Cat cat = generic.Generic(new Cat { Name = "小黑" });