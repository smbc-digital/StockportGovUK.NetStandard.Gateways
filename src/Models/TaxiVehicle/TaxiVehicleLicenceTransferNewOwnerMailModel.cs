using StockportGovUK.NetStandard.Gateways.Models.Mail;

namespace StockportGovUK.NetStandard.Gateways.Models.TaxiVehicle
{
    public class TaxiVehicleLicenceTransferNewOwnerMailModel : BaseMailModel
    {
        public string Reference { get; set; }
        public string Registration { get; set; }
    }
}