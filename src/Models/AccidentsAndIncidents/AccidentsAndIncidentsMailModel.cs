using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.AccidentsAndIncidents
{
    public class AccidentsAndIncidentsMailModel : BaseMailModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Reference { get; set; }
    }
}
