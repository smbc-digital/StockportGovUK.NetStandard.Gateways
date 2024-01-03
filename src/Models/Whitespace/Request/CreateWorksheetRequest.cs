using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;

public class CreateWorksheetRequest
{
    public string Uprn { get; set; }
    public string Usrn { get; set; }
    [Required]
    public int ServiceId { get; set; }
    [Required]
    public string CaseReference { get; set; }
    public string Message { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public IEnumerable<ServiceItemRequest> ServiceItems { get; set; }
    public IEnumerable<ServicePropertyRequest> ServiceProperties { get; set; }
    public int? AdHocRoundId { get; set; }
}
