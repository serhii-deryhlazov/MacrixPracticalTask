using System.ComponentModel.DataAnnotations;

namespace PeopleAPI.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string StreetName { get; set; }

    [Required]
    public string HouseNumber { get; set; }

    public string ApartmentNumber { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string Town { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}