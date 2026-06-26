using StockportGovUK.NetStandard.Gateways.Netcall.Models;
using Xunit;

namespace StockportGovUK.NetStandard.Gateways.Tests.Unit.Models
{
    public class ConverseCXRecordingRequestModelTests
    {
        [Theory]
        [InlineData(ConverseCXRecordingStateEnum.Pause, "pause")]
        [InlineData(ConverseCXRecordingStateEnum.Resume, "resume")]
        public void ToApiValue_ShouldMapRecordingStateToExpectedApiValue(ConverseCXRecordingStateEnum recordingState, string expected)
        {
            Assert.Equal(expected, recordingState.ToApiValue());
        }
    }
}
