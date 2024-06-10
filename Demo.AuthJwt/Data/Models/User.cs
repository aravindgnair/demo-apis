using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.AuthJwt.Data.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public bool IsAdmin { get; set; } = false;

    public bool IsDeleted { get; set; } = false;

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}