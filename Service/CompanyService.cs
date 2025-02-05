using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

public class CompanyService : ICompanyService
{
    private readonly AppDbContext _context;

    public CompanyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Company company)
    {
        await _context.Companies.AddAsync(company);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(Company company)
    {
        _context.Companies.Update(company);
        return await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company != null)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Company>> Get()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> GetById(int id)
    {
        return await _context.Companies.FindAsync(id);
    }
}
