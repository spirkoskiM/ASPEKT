using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _countryService.Get());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var country = await _countryService.GetById(id);
        if (country == null)
        {
            return NotFound();
        }
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Country country)
    {
        var result = await _countryService.Create(country);
        return CreatedAtAction(nameof(GetById), new { id = country.CountryId }, country);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Country country)
    {
        if (id != country.CountryId)
        {
            return BadRequest();
        }
        await _countryService.Update(country);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _countryService.Delete(id);
        return NoContent();
    }
}
