using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking;

public class Policy
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime? From { get; set; }

    public DateTime? Until { get; set; }

    public bool IsDefault { get; set; }

    public int AllowFutureBookingsUntil { get; set; }

    public DateTime DateCreated { get; set; }

    public DailyPolicy Monday { get; set; }

    public DailyPolicy Tuesday { get; set; }

    public DailyPolicy Wednesday { get; set; }

    public DailyPolicy Thursday { get; set; }

    public DailyPolicy Friday { get; set; }

    public DailyPolicy Saturday { get; set; }

    public DailyPolicy Sunday { get; set; }

    public Guid MondayId { get; set; }

    public Guid TuesdayId { get; set; }

    public Guid WednesdayId { get; set; }

    public Guid ThursdayId { get; set; }

    public Guid FridayId { get; set; }

    public Guid SaturdayId { get; set; }

    public Guid SundayId { get; set; }

    public bool IsCurrentlyActivePolicy { get; set; }

    public Guid ContextId { get; set; }

    public bool HasDailyPolicies => 
        Monday != null || Tuesday != null || Wednesday != null || 
        Thursday != null || Friday != null || Saturday != null || Sunday != null;
}