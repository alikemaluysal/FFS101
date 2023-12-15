using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class UserCreateModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(3)]
    [StringLength(50)]
    public string Username { get; set; }
    [Required]
    [MinLength(4)]
    [StringLength(10)]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
