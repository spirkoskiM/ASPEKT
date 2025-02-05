using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IContactService
    {
        Task<Contact> GetById(int id);
        Task<int> Create(Contact contact);
        Task<int> Update(Contact contact);
        Task Delete(int id);
        Task<List<Contact>> Get();
        Task<List<Contact>> GetContactsWithCompanyAndCountry();
        Task<List<Contact>> FilterContacts(int? countryId, int? companyId);
    }
}
