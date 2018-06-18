using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HPScanTo.Generated;
using Xunit;

namespace HPScanTo.Tests
{
    public class WalkupScanDestinationsTests
    {
        [Fact]
        public void ItContainsListOfDestinations()
        {
            using (var stream = GetRessource("WalkupScanDestinations.xml"))
            {
                var walkupScanDestinations = WalkupScanDestinations.CreateFromStream(stream);
                Assert.Equal(1, walkupScanDestinations.WalkupScanDestination.Count);
            }
        }

        private Stream GetRessource(string walkupscandestinationsXml)
        {
            var type = GetType();
            var assembly = type.GetTypeInfo().Assembly;
            var ressourceName = $"{type.Namespace}.ressources.{walkupscandestinationsXml}";
            return assembly.GetManifestResourceStream(ressourceName);
        }
    }
}