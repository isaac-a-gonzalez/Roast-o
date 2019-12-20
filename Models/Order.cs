using System;
using System.ComponentModel.DataAnnotations;

namespace Roastío.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public User UserOrdered { get; set; }
    public Product ProductOrdered { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

  }
}
