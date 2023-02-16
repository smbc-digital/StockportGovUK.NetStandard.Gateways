namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Context : BasicContext
{
    public bool IsDisabled { get; set; }
    public bool IsQueueing { get; set; }
    public string QueueId { get; set; }
    public bool IsUserLocationRequired { get; set; }
    public string EmailCustomerConfirmation { get; set; }
    public string EmailCustomerCancellation { get; set; }
    public string EmailCustomerReschedule { get; set; }
    public string EmailCustomerReminder { get; set; }
    public string EmailAdminConfirmation { get; set; }
    public string EmailAdminCancellation { get; set; }
    public string EmailAdminReschedule { get; set; }
    public string EmailCustomerConfirmationSubject { get; set; }
    public string EmailCustomerCancellationSubject { get; set; }
    public string EmailCustomerRescheduleSubject { get; set; }
    public string EmailCustomerReminderSubject { get; set; }
    public string EmailAdminConfirmationSubject { get; set; }
    public string EmailAdminCancellationSubject { get; set; }
    public string EmailAdminRescheduleSubject { get; set; }
    public bool EnableEmailReminder { get; set; }
    public int EmailReminderWindow { get; set; }
    public string SendReminderAt { get; set; }
    public string LocationType { get; set; }
    public string Location { get; set; }
    public bool EnableEffectiveSuspensionDate { get; set; }
    public string ResourceAdjustmentHeader { get; set; }
    public string ResourceAdjustmentHelpText { get; set; }
    public string SuspensionsHeader { get; set; }
    public string SuspensionsHelpText { get; set; }
}