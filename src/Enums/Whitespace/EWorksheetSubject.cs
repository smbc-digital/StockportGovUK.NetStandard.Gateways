﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace StockportGovUK.NetStandard.Gateways.Enums.Whitespace;

public enum EWorksheetSubject
{
    [Description("Assisted Collection Bin Not Returned Correctly")]
    AssistedCollectionBinNotReturnedCorrectly,
    [Description("Assisted Collection End")]
    AssistedCollectionEnd,
    [Description("Assisted Collection Missed")]
    AssistedCollectionMissed,
    [Description("Assisted Collection New")]
    AssistedCollectionNew,
    [Description("Assisted Collection Query")]
    AssistedCollectionQuery,
    [Description("Bin Not Returned Correctly")]
    BinNotReturnedCorrectly,
    [Description("Bulky Removal Request")]
    BulkyRemovalRequest,
    [Description("Collection Enquiry")]
    CollectionEnquiry,
    [Description("Container Delivery/Removal")]
    ContainerDeliveryRemoval,
    [Description("Container Delivery/Removal Missed")]
    ContainerDeliveryRemovalMissed,
    [Description("Container Maintenance")]
    ContainerMaintenance,
    [Description("Contamination Enquiry")]
    ContaminationEnquiry,
    [Description("Inappropriate Behaviour")]
    InappropriateBehaviour,
    [Description("Missed Collection AM")]
    MissedCollectionAm,
    [Description("Missed Collection PM")]
    MissedCollectionPm,
    [Description("Missed Collection Reported Late")]
    MissedCollectionReportedLate,
    [Description("Recycling Advice Requested")]
    RecyclingAdviceRequested,
    [Description("Request Container Assessment")]
    RequestContainerAssessment,
    [Description("Request For Monitoring")]
    RequestForMonitoring,
    [Description("Spillage After Collection")]
    SpillageAfterCollection,
    [Description("Waste Diary Request")]
    WasteDiaryRequest
}

public static class WorksheetSubjectEnumExtension
{
    public static string ToDescriptionString(this EWorksheetSubject? worksheetSubject)
    {
        if (worksheetSubject is null)
            return string.Empty;

        DescriptionAttribute[] attributes = (DescriptionAttribute[])worksheetSubject
                                                                    .GetType()
                                                                    .GetField(worksheetSubject.ToString())
                                                                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
        
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }

    public static EWorksheetSubject? ToEnumFromDescriptionString(this string worksheetSubject)
    {
        FieldInfo[] memberInfo = typeof(EWorksheetSubject).GetFields();

        foreach (var item in memberInfo)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])item.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes is not null && attributes.Length > 0 && attributes[0].Description.Equals(worksheetSubject))
                return (EWorksheetSubject)Enum.Parse(typeof(EWorksheetSubject), item.Name);
        }

        return null;
    }
}
