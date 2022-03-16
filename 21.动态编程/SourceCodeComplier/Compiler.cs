using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SourceCodeComplierDemo
{
    /// <summary>
    /// 编译器
    /// </summary>
    public static class Compiler
    {

        private static Dictionary<string, CollectibleAssemblyLoadContext> loadContexts = new Dictionary<string, CollectibleAssemblyLoadContext>();

        /// <summary>
        /// 将代码编译为dll文件
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="assemblyName">编译的程序集名称</param>
        /// <param name="referencedAssemblies">要引用的程序集</param>
        /// <returns>
        /// <para>outputPath: dll文件地址</para>
        /// <para>xmlDocPath: xml文件地址</para>
        /// </returns>
        public static (string outputPath, string xmlDocPath) CompileToDll(string code, string assemblyName, IEnumerable<Assembly> referencedAssemblies)
        {
            var references = referencedAssemblies.Where(a => !string.IsNullOrWhiteSpace(a.Location)).Select(it => MetadataReference.CreateFromFile(it.Location));

            var compilation = CSharpCompilation.Create(assemblyName)
              .WithOptions(new CSharpCompilationOptions(
                  OutputKind.DynamicallyLinkedLibrary,
                  usings: null,
                  optimizationLevel: OptimizationLevel.Debug,
                  checkOverflow: false,
                  allowUnsafe: true,
                  platform: Platform.AnyCpu,
                  warningLevel: 4,
                  xmlReferenceResolver: null // don't support XML file references in interactive (permissions & doc comment includes)
                  ))
              .AddReferences(references)
              .AddSyntaxTrees(CSharpSyntaxTree.ParseText(code));

            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", assemblyName + ".dll");
            //string pdbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", assemblyName + ".pdb");
            string xmlDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", assemblyName + ".xml");
            var dir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var emitResult = compilation.Emit(outputPath: outputPath, xmlDocPath: xmlDocPath);
            if (emitResult.Success)
            {
                return (outputPath, xmlDocPath);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("编译出错, 详情如下: ");
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                sb.AppendLine(diagnostic.ToString());
            }

            throw new InvalidOperationException(sb.ToString());
        }

        /// <summary>
        /// 加载DLL文件, 若文件名称相同, 则会将之前的LoadContext卸载
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Assembly LoadDll(string filePath)
        {
            // 重新生成context
            FileInfo dllFile = new FileInfo(filePath);

            // 先尝试清除
            if (loadContexts.Remove(dllFile.Name, out var oldContext))
            {
                // FIX 卸载不掉, 需要排查原因
                oldContext.Unload();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            // 新创建一个
            CollectibleAssemblyLoadContext context = new CollectibleAssemblyLoadContext(dllFile.Name);

            Assembly assembly = null;
            using (var stream = File.OpenRead(filePath))
            {
                assembly = context.LoadFromStream(stream);
            }
            loadContexts.Add(context.Name, context);

            return assembly;
        }
    }
}
