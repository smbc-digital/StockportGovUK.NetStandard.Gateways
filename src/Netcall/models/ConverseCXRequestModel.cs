using Newtonsoft.Json;

namespace StockportGovUK.NetStandard.Gateways.Netcall.Models
{
    public class ConverseCXRequestModel
    {
        public const string RECORDINGSTATE_PAUSE = "pause";
        public const string RECORDINGSTATE_RESUME = "resume";

        public enum RecordingStateValue
        {
            Pause,
            Resume
        }

        public ConverseCXRequestModel(RecordingStateValue recordingState, string agentId)
        {
            SetRecordingState(recordingState);
            AgentId = agentId;
        }

        [JsonProperty("agentId")]
        public string AgentId { get; private set; }

        [JsonProperty("recordingState")]
        public string RecordingState { get; private set; }

        private void SetRecordingState(RecordingStateValue recordingState)
        {
            RecordingState = recordingState == RecordingStateValue.Pause ? RECORDINGSTATE_PAUSE : RECORDINGSTATE_RESUME;
        }
    }
}


