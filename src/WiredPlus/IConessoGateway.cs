using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public interface IConessoGateway : IGateway
    {
        Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request);
        Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request);
        Task<HttpResponse<List>> GetListById(int listId);
        Task<HttpResponse<ListResponse>> GetLists();
        Task<HttpResponse<ContactResponse>> GetContactByEmail(string emailAddress);
        Task<HttpResponse<Contact>> GetContactById(int contactId);

    }
}
