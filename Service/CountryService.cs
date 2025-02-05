using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

public class CountryService : ICountryService
{
    private readonly AppDbContext _context;

    public CountryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Country country)
    {
        await _context.Countries.AddAsync(country);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(Country country)
    {
        _context.Countries.Update(country);
        return await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country != null)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Country>> Get()
    {
        return await _context.Countries.ToListAsync();
    }

    public async Task<Country?> GetById(int id)
    {
        return await _context.Countries.FindAsync(id);
    }
}
