using System;

namespace StockportGovUK.NetStandard.Gateways.Models.ComplimentsComplaints
{
    public class ComplaintDetails
    {
        public Guid Guid { get; set; }

        public string ComplainAbout { get; set; }

        public string CouncilDepartment { get; set; }

        public string CouncilDepartmentSub { get; set; }

        public string OtherService { get; set; }

        public string ComplainAboutService { get; set; }

        public string ComplainAboutDetails { get; set; }

        public ContactDetails.ContactDetails ContactDetails { get; set; }

        public string EventCode { get; set; }
    }
}
