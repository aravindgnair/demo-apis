using System.ComponentModel.DataAnnotations;

namespace Demo.AuthJwt.Dto;

public class NewUserDto
{
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}