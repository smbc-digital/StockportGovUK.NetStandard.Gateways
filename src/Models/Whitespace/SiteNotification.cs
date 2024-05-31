using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Whitespace;
public class SiteNotification
{
    public string NotificationName { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public int SiteId { get; set; }
    public string SiteServiceNotificationNotes { get; set; }
    public DateTime SiteServiceNotificationValidFrom { get; set; }
    public DateTime SiteServiceNotificationValidTo { get; set; }
}
