using System;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class ExportField
{
    public Guid Id { get; set; }
    public string ColumnHeading { get; set; }
    public EExportMapping ExportFieldType { get; set; }
    public int DisplayIndex { get; set; }
    public string MetaDataFieldKey { get; set; }
    public Guid ExportId { get; set; }
}
