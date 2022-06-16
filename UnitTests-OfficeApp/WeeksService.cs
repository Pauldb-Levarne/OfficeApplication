using OfficeAppLevarne.Services;
using Xunit;

namespace UnitTests_OfficeApp
{
    public class WeeksService
    {

        [Fact]
        public async Task RecieveWeeks()
        {
            OfficeAppLevarne.Services.WeeksService weeks = new();
            var recieveValues = await weeks.GetWeeks();
            Assert.NotNull(recieveValues);
        }
    }
}