namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{


    public class PaymentDetail
    {
        private string paymentNarrative;

        public string CatalogueID { get; set; }

        public string AccountReference { get; set; }

        public string AltAccountReference { get; set; }

        public string PaymentAmount { get; set; }

        public string Quantity { get; set; }

        public string VATCode { get; set; }

        public string PaymentNarrative { get => $"{paymentNarrative} (ref: {CallingAppTranReference})"; set => paymentNarrative = value; }

        public string TelephoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string ServicePayReference { get; set; }

        public string ServicePayNarrative { get; set; }

        public string ServicePayItemDesc { get; set; }

        public string PupilName { get; set; }

        public string SchoolDFES { get; set; }

        public string SchoolItemCode { get; set; }

        public string SchoolItemDescription { get; set; }

        public string SchoolPayItemRef { get; set; }

        public string GiftAid { get; set; }

        public string PaymentNotificationURL { get; set; }

        public string CallingAppTranReference { get; set; }
    }
}