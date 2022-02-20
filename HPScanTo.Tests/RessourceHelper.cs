using System;
using System.IO;
using System.Reflection;

namespace HPScanTo.Tests
{
    public class RessourceHelper
    {
        public static Stream GetRessource(string ressourceName)
        {
            Type type = typeof(RessourceHelper);
            Assembly assembly = type.GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream($"{type.Namespace}.ressources.{ressourceName}");
        }

        public static string GetRessourceAsString(string ressourceName)
        {
            using (Stream stream = RessourceHelper.GetRessource(ressourceName))
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}