using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeComplierDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load);

            // 需要添加当前项目没有引用, 但是动态代码中引用了的程序集
            allAssemblies = allAssemblies.Union(new[] { typeof(object).Assembly, typeof(Console).Assembly });

            string sourceCode = @"using System;

namespace TestModule
{
    public static class Test
    {
        public static void SayHello()
        {
            Console.WriteLine(""Hello"");
        }
    }
}
";
            string assemblyName = "TestModule";
            // 先生成dll文件
            var (outputPath, xmlDocPath) = Compiler.CompileToDll(sourceCode, assemblyName, allAssemblies);

            // 从dll读取到程序集
            var assembly = Compiler.LoadDll(outputPath);

            // 调用静态方法
            var method = assembly.GetType("TestModule.Test").GetMethod("SayHello");
            method.Invoke(null, null);
        }
    }
}
