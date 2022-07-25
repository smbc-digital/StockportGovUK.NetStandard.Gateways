using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.WiredPlus
{
    public class GetListByIdRequest
    {
        [Required]
        [MaxLength(11)]
        public int Id { get; set; }

        public GetListByIdRequest(int id) => Id = id;
    }
}
