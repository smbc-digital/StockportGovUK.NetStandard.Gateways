using System;
using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class UpdateAdditionalInformationMetaDataValuesRequest
    {
        public UpdateAdditionalInformationMetaDataValuesRequest() { }

        public UpdateAdditionalInformationMetaDataValuesRequest(Guid bookingId, List<AdditionalInformationMetaDataValue> additionalInformationMetaData)
            => (BookingId, AdditionalInformationMetaData) = (bookingId, additionalInformationMetaData);

        public Guid BookingId { get; set; }

        public List<AdditionalInformationMetaDataValue> AdditionalInformationMetaData { get; set; }
    }

    public class AdditionalInformationMetaDataValue
    {
        public AdditionalInformationMetaDataValue() { }

        public AdditionalInformationMetaDataValue(string key, string value)
            => (Key, Value) = (key, value);

        public AdditionalInformationMetaDataValue(string key, string value, string dropdownId)
            => (Key, Value, DropdownId) = (key, value, dropdownId);

        public string Key { get; set; }

        public string Value { get; set; }

        public string DropdownId { get; set; }
    }
}
