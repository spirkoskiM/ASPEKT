using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;

        public ContactService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Contact contact) =>
            (await _context.Contacts.AddAsync(contact)).Context.SaveChanges();

        public async Task<int> Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            return await _context.SaveChangesAsync();
        }

        public async Task Delete(int id) =>
            await Task.Run(() =>
            {
                var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == id);
                if (contact != null) _context.Contacts.Remove(contact);
                _context.SaveChanges();
            });

        public async Task<List<Contact>> Get() =>
            await _context.Contacts.ToListAsync();

        public async Task<Contact> GetById(int id) // Ensure this exists
        {
            return await _context.Contacts.FindAsync(id);
        }


        public async Task<List<Contact>> GetContactsWithCompanyAndCountry() =>
            await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();

        public async Task<List<Contact>> FilterContacts(int? countryId, int? companyId) =>
            await _context.Contacts
                .Where(c => (countryId == 0 || c.CountryId == countryId) &&
                            (companyId == 0 || c.CompanyId == companyId))
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
    }
}
