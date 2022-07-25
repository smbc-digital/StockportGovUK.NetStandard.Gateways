using System.Xml.Serialization;

namespace StockportGovUK.NetStandard.Gateways.Models.RevsAndBens
{
    [XmlRoot("StandardInfo")]
    public class StandardInfo
    {
        [XmlElement("SessionID")]
        public string SessionID { get; set; }
        [XmlElement("LoggedIn")]
        public string LoggedIn { get; set; }
        [XmlElement("SIDString")]
        public string SIDString { get; set; }
        [XmlElement("BaseURL")]
        public string BaseURL { get; set; }
        [XmlElement("PageName")]
        public string PageName { get; set; }
        [XmlElement("HTTPReferer")]
        public HTTPReferer HTTPReferer { get; set; }
        [XmlElement("QueryString")]
        public string QueryString { get; set; }
        [XmlElement("CurrentQueryString")]
        public CurrentQueryString CurrentQueryString { get; set; }
        [XmlElement("AuthorityDefaults")]
        public AuthorityDefaults AuthorityDefaults { get; set; }
        [XmlElement("Today")]
        public Today Today { get; set; }
    }

    [XmlRoot("HTTPReferer")]
    public class HTTPReferer
    {
        [XmlAttribute("Docid")]
        public string Docid { get; set; }
    }

    [XmlRoot("CurrentQueryString")]
    public class CurrentQueryString
    {
        [XmlElement("viewset")]
        public string Viewset { get; set; }
        [XmlElement("outputtype")]
        public string Outputtype { get; set; }
        [XmlElement("docid")]
        public string Docid { get; set; }
        [XmlElement("sessionId")]
        public string SessionId { get; set; }
    }

    [XmlRoot("AuthorityDefaults")]
    public class AuthorityDefaults
    {
        [XmlElement("AuthorityName")]
        public string AuthorityName { get; set; }
        [XmlElement("AuthorityLogo")]
        public string AuthorityLogo { get; set; }
        [XmlElement("TimeOut")]
        public TimeOut TimeOut { get; set; }
    }

    [XmlRoot("TimeOut")]
    public class TimeOut
    {
        [XmlAttribute("TimeOutValue")]
        public string TimeOutValue { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot("Today")]
    public class Today
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }
        [XmlAttribute("DateSort")]
        public string DateSort { get; set; }
        [XmlAttribute("Time")]
        public string Time { get; set; }
    }
}