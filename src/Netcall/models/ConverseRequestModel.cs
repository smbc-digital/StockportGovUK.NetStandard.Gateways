using System;

namespace StockportGovUK.NetStandard.Gateways.Netcall.Models
{
    public class ConverseRequestModel
    {
        public const string RECORDINGSTATE_PAUSE = "pause";
        public const string RECORDINGSTATE_RESUME = "resume";

        public const string IDENTIFIERTYPE_USERID = "userid";
        public const string IDENTIFIERTYPE_EXTENSION = "extension";
        public const string IDENTIFIERTYPE_USERNAME = "username";

        private string _IdentifierType;

        private string _RecordingState;

        public string Identifier { get; set; }

        public string IdentifierType
        {
            get { return _IdentifierType; }
            set
            {

                if (!value.Equals(IDENTIFIERTYPE_USERID) && !value.Equals(IDENTIFIERTYPE_EXTENSION) && !value.Equals(IDENTIFIERTYPE_USERNAME))
                {
                    throw new ArgumentException("IdentifierType must be userid, extension or username");
                }

                _IdentifierType = value;
            }
        }

        public string RecordingState
        {
            get { return _RecordingState; }
            set
            {

                if (!value.Equals(RECORDINGSTATE_PAUSE) && !value.Equals(RECORDINGSTATE_RESUME))
                {
                    throw new ArgumentException("RecordingSate must be pause or resume");
                }

                _RecordingState = value;
            }
        }
    }
}


