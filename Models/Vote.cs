using System;
using System.ComponentModel.DataAnnotations;

namespace Roastío.Models
{
  public class Vote
  {
    [Key]
    public int VoteId { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public bool IsUpvote { get; set; }
    public User UserVoted { get; set; }
    public Post PostVoted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

  }
}
