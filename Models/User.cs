using System;               // Models/User.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Roastío.Models
{
  public class User
  {
    [Key] // denotes Primary Key, not needed if named ModelNameId
    public int UserId { get; set; }
    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "is required.")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters.")]
    [DataType(DataType.Password)]  // auto fills the input type attribute
    public string Password { get; set; }
    [NotMapped]  // this means "don't add it to the DB(database)!" It would be a waste of space.
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "doesn't match password")]
    [Display(Name = "Confirm Password")]
    public string PasswordConfirm { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Post> UsersPosts { get; set; }
    public List<Order> UsersOrders { get; set; }
    public List<Product> ProductsOrderedByUser { get; set; }
    public List<Vote> Votes { get; set; }

  }
}
