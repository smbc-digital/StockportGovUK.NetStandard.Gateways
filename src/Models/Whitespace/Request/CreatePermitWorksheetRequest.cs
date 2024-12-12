using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
public class CreatePermitWorksheetRequest
{
    public string Uprn { get; set; }
    [Required]
    public int ServiceId { get; set; }
    public string CaseReference { get; set; }
    public string VerintOnlineFormReference { get; set; }
    public string Message { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Quantity { get; set; }
    public IEnumerable<ServicePropertyRequest> ServiceProperties { get; set; }
    public Verint.Address Address { get; set; }
    public string DiscountType { get; set; }
}
