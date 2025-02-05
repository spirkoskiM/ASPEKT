using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _contactService.Get());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Contact contact)
    {
        var result = await _contactService.Create(contact);
        return CreatedAtAction(nameof(GetById), new { id = contact.ContactId }, contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
    {
        if (id != contact.ContactId)
        {
            return BadRequest();
        }
        await _contactService.Update(contact);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contactService.Delete(id);
        return NoContent();
    }

    [HttpGet("FilterContacts")]
    public async Task<IActionResult> FilterContacts([FromQuery] int? countryId, [FromQuery] int? companyId)
    {
        var filteredContacts = await _contactService.FilterContacts(countryId, companyId);
        return Ok(filteredContacts);
    }

    [HttpGet("WithCompanyAndCountry")]
    public async Task<IActionResult> GetContactsWithCompanyAndCountry()
    {
        var contacts = await _contactService.GetContactsWithCompanyAndCountry();
        return Ok(contacts);
    }
}
