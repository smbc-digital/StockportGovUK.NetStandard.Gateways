using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Export
{
    public Guid Id { get; set; }
    public string ExportName { get; set; }
    public List<string> ColumnNames { get; set; }
    public List<List<string>> RowData { get; set; }
    public List<ExportField> ExportFields { get; set; }
}
