using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint.Attributes
{
    public class MaxLength : Attribute
    {
        public MaxLength(int length)
        {
            Length = length;
        }

        public int Length { get; set; }
    }
}
