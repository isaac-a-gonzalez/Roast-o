using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Roastío.Models
{
  public class User : IdentityUser
  {

  }

  public class SignInManager<User> where User : class
  {
    public virtual bool IsSignedIn(System.Security.Claims.ClaimsPrincipal principal);
  }

  public class UserManager<User> : IDisposable where User : class
  {

  }
}
