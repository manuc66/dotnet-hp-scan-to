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
            using (var stream = RessourceHelper.GetRessource("WalkupScanDestinations.xml"))
            {
                var walkupScanDestinations = WalkupScanDestinations.CreateFromStream(stream);
                Assert.Equal(1, walkupScanDestinations.WalkupScanDestination.Count);
            }
        }

        [Fact]
        public void SampleContainsAKnownDestinationName()
        {
            using (var stream =  RessourceHelper.GetRessource("WalkupScanDestinations.xml"))
            {
                var walkupScanDestinations = WalkupScanDestinations.CreateFromStream(stream);
                Assert.True(walkupScanDestinations.WalkupScanDestination.Any(x => x.Name == "DESKTOP-JI67N1P"));
            }
        }

    }
}