using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StockportGovUK.NetStandard.Gateways.Netcall.Models
{
    public partial class ConverseCXRecordingRequestModel
    {

        public ConverseCXRecordingRequestModel(ConverseCXRecordingStateEnum recordingState, string agentId = null, string agentEmail = null)
        {
            RecordingState = recordingState.ToApiValue();
            AgentId = agentId;
        }

        [JsonProperty("agentId")]
        public string AgentId { get; private set; }

        [JsonProperty("agentEmail")]
        public string AgentEmail { get; private set; }

        [Required]
        [JsonProperty("recordingState")]
        public string RecordingState { get; private set; }

    }
}


