using System.IO;
using System.Reflection;

namespace HPScanTo.Tests
{
    public class RessourceHelper
    {
        public static Stream GetRessource(string ressourceName)
        {
            var type = typeof(RessourceHelper);
            var assembly = type.GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream($"{type.Namespace}.ressources.{ressourceName}");
        }

        public static string GetRessourceAsString(string ressourceName)
        {
            using (var stream = RessourceHelper.GetRessource(ressourceName))
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}