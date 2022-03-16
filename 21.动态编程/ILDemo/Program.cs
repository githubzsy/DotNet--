// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");
var method = new DynamicMethod("Test",null,Type.EmptyTypes);
var generator = method.GetILGenerator();
generator.Emit(OpCodes.Ldstr,"Emit Test");
generator.Emit(OpCodes.Call,typeof(Console).GetMethod("WriteLine",new Type[] { typeof(string) }));
generator.Emit(OpCodes.Ret);

var m  = method.CreateDelegate(typeof(Action)) as Action;
m();