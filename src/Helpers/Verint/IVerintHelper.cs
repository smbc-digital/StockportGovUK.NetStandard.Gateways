using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm;

namespace StockportGovUK.NetStandard.Gateways.Helpers.Verint;

public interface IVerintHelper
{
    Task<VerintOnlineFormResponse> CreateVerintOnlineFormCase(VerintOnlineFormRequest request);
    Task AddFormDataToVerintOnlineForm(VerintOnlineFormUpdateRequest request, bool logOnly = false);
}
