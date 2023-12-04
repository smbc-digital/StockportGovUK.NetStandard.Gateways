using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;

public class SiteService 
{
    public int Id { get; set; }
    public int SiteId { get; set; }
    public int AccountSiteId { get; set; }
    public int ServiceItemId { get; set; }
    public string ServiceItemName { get; set; }
    public string ServiceItemDescription { get; set; }
    public string ServiceItemSerialNumber { get; set; }
    public string ServiceItemChipNumber { get; set; }
    public string ServiceItemUniqueNumber { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ContractValidTo { get; set; }
    public DateTime ValidTo { get; set; }
    public DateTime BlockedFrom { get; set; }
    public string Notes { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public int ContractId { get; set; }
    public string ContractName { get; set; }
    public string ContractDescription { get; set; }
    public DateTime ContractValidFrom { get; set; }
    public int ContractTypeId { get; set; }
    public string ContractTypeName { get; set; }
    public string ContractTypeDescription { get; set; }
    public int Quantity { get; set; }
    public double Charge { get; set; }
    public double Cost { get; set; }
    public DateTime CssiValidFrom { get; set; }
    public DateTime CssiValidTo { get; set; }
    public string ProductCode;
    public int ChargeTypeId { get; set; }
    public string ChargeTypeName { get; set; }
    public bool PerCollection { get; set; }
    public bool PerLift { get; set; }
    public bool PerKg { get; set; }
    public int PaymentScheduleId { get; set; }
    public string PaymentScheduleName { get; set; }
    public string PaymentScheduleDescription { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentMethodName { get; set; }
    public string PaymentMethodDescription { get; set; }
    public bool GenerateTransaction { get; set; }
    public string RoundSchedule { get; set; }
    public int SiteContractId { get; set; }
    public string ContractStatusCode { get; set; }
    public string EwcCode { get; set; }
    public decimal ItemQuantity { get; set; }
    public int ItemId { get; set; }
    public DateTime? NextCollectionDate { get; set; }
}
