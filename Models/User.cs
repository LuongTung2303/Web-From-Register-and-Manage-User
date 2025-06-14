using System.ComponentModel.DataAnnotations;

namespace WebFormRegister.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }
}