using HPScanTo.Generated;
using Xunit;

namespace HPScanTo.Tests
{
    public class WalkupScanDestinationPostTests
    {
        [Fact]
        public void SampleContainsAKnownDestinationName()
        {
            var expected = RessourceHelper.GetRessourceAsString("WalkupScanDestination.xml");

            var walkupScanDestinations = WalkupScanDestinationPost.CreateFrom("LAPTOP-BSHRTBV8", "LAPTOP-BSHRTBV8");

            var serializeToXml = walkupScanDestinations.SerializeToXml();
            Assert.Equal(expected, serializeToXml);
        }
    }
}