using PeopleAPI.Models;

namespace PeopleAPI.Interfaces;

public interface IPersonService
{
    public Task<List<Person>> GetAllAsync();
    
    public Task<Person?> GetAsync(int id);

    public Task<Person> AddAsync(Person person);

    public Task<Person> UpdateAsync(Person existingPerson, Person updatedPerson);
    
    public Task DeleteAsync(Person person);
}