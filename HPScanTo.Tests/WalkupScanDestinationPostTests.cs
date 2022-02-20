using HPScanTo.Generated;
using Xunit;

namespace HPScanTo.Tests
{
    public class WalkupScanDestinationPostTests
    {
        [Fact]
        public void SampleContainsAKnownDestinationName()
        {
            string expected = RessourceHelper.GetRessourceAsString("WalkupScanDestination.xml");

            WalkupScanDestinationPost walkupScanDestinations = WalkupScanDestinationPost.CreateFrom("LAPTOP-BSHRTBV8", "LAPTOP-BSHRTBV8");

            string serializeToXml = walkupScanDestinations.SerializeToXml();
            Assert.Equal(expected, serializeToXml);
        }
    }
}