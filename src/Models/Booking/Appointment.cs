using System;
using System.Collections.Generic;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Appointment
{
    public Guid Id { get; set; }

    public Guid BookingContextId { get; set; }

    public string Name { get; set; }

    public TimeSpan Length { get; set; }

    public TimeSpan BookingLimit { get; set; }

    public string DefaultContactEmail { get; set; }

    public bool SendNotifications { get; set; }

    public bool SendRescheduleNotifications { get; set; }

    public bool SendCancellationNotifications { get; set; }

    public TimeSpan UnconfirmedTimeoutLength { get; set; }

    public bool AllowWaitingLists { get; set; }

    public string UserPreBookingMessage { get; set; }

    public bool ShowEndTimeWhenBooking { get; set; }

    public Guid DefaultStatusId { get; set; }

    public Status DefaultStatus { get; set; }

    public List<AppointmentResource> AppointmentResources { get; set; }

    public List<Suspension> Suspensions { get; set; }

    public List<Status> Statuses { get; set; }

    public bool IsCurrentlySuspended { get; set; }

    public decimal? Cost { get; set; }

    public bool InternalOnly { get; set; }

    public bool IsHidden { get; set; }

    public int DisplayIndex { get; set; }

    public bool SendNewBookingConfirmation { get; set; }

    public bool AllowCancellation { get; set; }

    public TimeSpan MinCustomerCancellationTime { get; set; }

    public bool CancelOnlyOnAWorkingDay { get; set; }

    public bool AllowLateCancellation { get; set; }

    public bool AllowCustomerCancellation { get; set; }

    public bool SendCancelBookingConfirmation { get; set; }

    public string LateCancellationMessage { get; set; }

    public string CancellationMessage { get; set; }

    public string CancelUrl { get; set; }

    public bool AllowRescheduling { get; set; }

    public bool AllowCustomerRescheduling { get; set; }

    public TimeSpan ReschedulingLimit { get; set; }

    public bool RescheduleOnlyOnAWorkingDay { get; set; }

    public bool AllowLateRescheduling { get; set; }

    public string LateRescheduleMessage { get; set; }

    public string RescheduleMessage { get; set; }

    public bool SendRescheduleBookingConfirmation { get; set; }

    public string RescheduleUrl { get; set; }

    public int OptionalResourcesMin { get; set; }

    public int OptionalResourcesMax { get; set; }

    public bool TimeTrackingEnabled { get; set; }

    public string AdditionalInformation { get; set; }

    public EOptionalResourceDisplayMode OptionalResourceDisplay { get; set; }

    public string SuspensionsHeader { get; set; }

    public string SuspensionsHelpText { get; set; }

    public List<MetaDataField> MetaDataFields { get; set; }
}