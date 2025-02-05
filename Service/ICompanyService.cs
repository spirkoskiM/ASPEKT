using WebAPI.Models;

public interface ICompanyService
{
    Task<int> Create(Company company);
    Task<int> Update(Company company);
    Task Delete(int id);
    Task<List<Company>> Get();
    Task<Company?> GetById(int id);
}
