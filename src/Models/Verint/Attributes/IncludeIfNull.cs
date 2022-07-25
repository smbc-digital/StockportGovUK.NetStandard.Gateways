using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IncludeIfNull : Attribute
    {
    }
}
