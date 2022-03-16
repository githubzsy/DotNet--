using System.Reflection;
using System.Runtime.Loader;

namespace SourceCodeComplierDemo
{
    public class CollectibleAssemblyLoadContext
     : AssemblyLoadContext
    {

        public CollectibleAssemblyLoadContext(string name) : base(name, isCollectible: true)
        {
        }
    }
}
