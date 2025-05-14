using System.Collections.Concurrent;
using System.Reflection;

namespace LetGetAPass.Properties
{
    /// <summary>Provides simple resource feature. </summary>
    public class PortableResources
    {
        private readonly object access = new();
        private readonly ConcurrentDictionary<string, (int Refs, object? Value)> cachedResources = [];
        private readonly Assembly asm = Assembly.GetAssembly(typeof(PortableResources))!;

        public PortableResources()
        {

        }

        private static PortableResources? instance = null;
        public static PortableResources Instance => instance ??= new();

        public object? GetResource(string name)
        {

        }
        public T? GetResource<T>(string name)
        {
            
        }

        public void ReturnResource(string name, object? value)
        {

        }
    }
}