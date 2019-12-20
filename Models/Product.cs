using System;
using System.ComponentModel.DataAnnotations;

namespace Roastío.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public User Purchaser { get; set; }

  }
}
