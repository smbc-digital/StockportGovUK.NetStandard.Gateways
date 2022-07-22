using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Organisation
{
    public class OrganisationSearch
    {
        [Required]
        public EOrganisationProvider OrganisationProvider { get; set; }

        [Required]
        [MinLength(3)]
        public string SearchTerm { get; set; }
    }
}
