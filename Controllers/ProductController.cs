using Roastío.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roastío.Controllers
{
  public class ProductController : Controller
  {
    private MyContext DbContext;


    public ProductController(MyContext context)
    {
      DbContext = context;
    }

    public IActionResult ProductsLink()
    {
      return View("AllProducts");
    }
  }
}
