using System;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Booking.Request
{
    public class UpdateCustomerForBookingRequest
    {
        
        /// <summary>
        /// Id of the booking to update
        /// </summary>
        /// <value></value>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Optional Id of the customer if known.
        /// </summary>
        /// <value></value>
        public Guid? CustomerId  { get; set; }

        /// <summary>
        /// Customer information if Id is not known or customer is new
        /// </summary>
        /// <value></value>
        public Customer Customer { get; set; }
    }
}