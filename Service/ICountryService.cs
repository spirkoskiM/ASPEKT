using WebAPI.Models;

public interface ICountryService
{
    Task<int> Create(Country country);
    Task<int> Update(Country country);
    Task Delete(int id);
    Task<List<Country>> Get();
    Task<Country?> GetById(int id);
}
