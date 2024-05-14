using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public interface IConessoGateway : IGateway
    {
        Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request);
        Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request);
        Task<HttpResponse<ListResponse>> GetListById(int listId);
        Task<HttpResponse<ListsResponse>> GetLists();
        Task<HttpResponse<ContactsResponse>> GetContactByEmail(string emailAddress);
        Task<HttpResponse<ContactResponse>> GetContactById(int contactId);
    }
}
