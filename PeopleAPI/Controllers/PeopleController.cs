using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Interfaces;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return await _personService.GetAllAsync();
    }

    [HttpPost]
    public async Task<Person> AddPerson([FromBody] Person person)
    {
        if (ModelState.IsValid)
        {
            return await _personService.AddAsync(person);
        }
        else
        {
            throw new ArgumentException("Invalid person data");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person updatedPerson)
    {
        var existingPerson = await _personService.GetAsync(updatedPerson.Id);

        if (existingPerson == null)
        {
            return NotFound();
        }
        
        return await _personService.UpdateAsync(existingPerson, updatedPerson);
    }

    [HttpDelete("{id}")]
    public async Task DeletePerson(int id)
    {
        var existingPerson = await _personService.GetAsync(id);

        if (existingPerson != null)
        {
            await _personService.DeleteAsync(existingPerson);
        }
    }
}