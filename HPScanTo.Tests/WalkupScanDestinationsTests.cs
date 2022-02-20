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
            using (Stream stream = RessourceHelper.GetRessource("WalkupScanDestinations.xml"))
            {
                WalkupScanDestinations walkupScanDestinations = WalkupScanDestinations.CreateFromStream(stream);
                Assert.Single(walkupScanDestinations.WalkupScanDestination);
            }
        }

        [Fact]
        public void SampleContainsAKnownDestinationName()
        {
            using (Stream stream =  RessourceHelper.GetRessource("WalkupScanDestinations.xml"))
            {
                WalkupScanDestinations walkupScanDestinations = WalkupScanDestinations.CreateFromStream(stream);
                Assert.Contains(walkupScanDestinations.WalkupScanDestination, x => x.Name == "DESKTOP-JI67N1P");
            }
        }

    }
}