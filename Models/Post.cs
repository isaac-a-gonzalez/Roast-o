using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roastío.Models
{
  public class Post
  {
    [Key]
    public int PostId { get; set; }

    [Required(ErrorMessage = "Field is required")]
    [DataType(DataType.Text)]
    [MaxLength(200, ErrorMessage = "No more than 200 characters")]
    [Display(Name = "Tell us your coffee stories")]
    public string Content { get; set; }

    public DateTime CreatedAt
    { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User UserPosted { get; set; }
    public List<Vote> Votes { get; set; }
  }
}
