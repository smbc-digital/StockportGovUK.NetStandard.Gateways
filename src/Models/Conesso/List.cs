using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Conesso
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public bool OptInRequired { get; set; }
        public int ContactNo { get; set; }
        public string[] Tags {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
    }
}
