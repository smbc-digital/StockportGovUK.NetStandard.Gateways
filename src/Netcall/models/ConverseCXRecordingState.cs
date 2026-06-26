using System;

namespace StockportGovUK.NetStandard.Gateways.Netcall.Models
{
    public enum ConverseCXRecordingStateEnum
    {
        Pause,
        Resume
    }

    public static class ConverseCXRecordingStateExtensions
    {
        public static string ToApiValue(this ConverseCXRecordingStateEnum recordingState)
            => recordingState switch
            {
                ConverseCXRecordingStateEnum.Pause => "pause",
                ConverseCXRecordingStateEnum.Resume => "resume",
                _ => throw new ArgumentOutOfRangeException(nameof(recordingState), recordingState, null)
            };
    }
}


