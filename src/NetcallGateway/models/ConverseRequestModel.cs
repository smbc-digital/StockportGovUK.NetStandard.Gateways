namespace StockportGovUK.NetStandard.Gateways.Netcall.Models
{
    public class ConverseRequestModel
    {
        public string Identifier { get; set; }
        public IdentifierType IdentifierType { get; set; }
        public RecordingState RecordingState { get; set; }
    }

    public class RecordingState
    {
        private RecordingState(string value) { Value = value; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public static RecordingState Pause { get { return new RecordingState("pause"); } }
        public static RecordingState Resume { get { return new RecordingState("resume"); } }
    }

    public class IdentifierType
    {
        private IdentifierType(string value) { Value = value; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public static IdentifierType UserId { get { return new IdentifierType("userid"); } }
        public static IdentifierType Extension { get { return new IdentifierType("extension"); } }
        public static IdentifierType Username { get { return new IdentifierType("username"); } }

    }
}


