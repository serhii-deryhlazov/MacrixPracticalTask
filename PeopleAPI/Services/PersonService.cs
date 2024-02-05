using Microsoft.EntityFrameworkCore;
using PeopleAPI.Interfaces;
using PeopleAPI.Models;
using PeopleAPI.Persistence;

namespace PeopleAPI.Services;

public class PersonService : IPersonService
{
    private readonly PeopleDbContext _dbContext;

    public PersonService(PeopleDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Person>> GetAllAsync()
    {
        return await _dbContext.People.ToListAsync();
    }

    public async Task<Person?> GetAsync(int id)
    {
        return await _dbContext.People.FirstOrDefaultAsync(p=>p.Id == id);
    }

    public async Task<Person> AddAsync(Person person)
    {
        _dbContext.People.Add(person);
        await _dbContext.SaveChangesAsync();

        return person;
    }

    public async Task<Person> UpdateAsync(
        Person existingPerson, Person updatedPerson)
    {
        existingPerson.FirstName = updatedPerson.FirstName;
        existingPerson.LastName = updatedPerson.LastName;
        existingPerson.StreetName = updatedPerson.StreetName;
        existingPerson.HouseNumber = updatedPerson.HouseNumber;
        existingPerson.ApartmentNumber = updatedPerson.ApartmentNumber;
        existingPerson.PostalCode = updatedPerson.PostalCode;
        existingPerson.Town = updatedPerson.Town;
        existingPerson.PhoneNumber = updatedPerson.PhoneNumber;
        existingPerson.DateOfBirth = updatedPerson.DateOfBirth;

        await _dbContext.SaveChangesAsync();
        
        return existingPerson;
    }

    public async Task DeleteAsync(Person person)
    {
        _dbContext.People.Remove(person);

        await _dbContext.SaveChangesAsync();
    }
}