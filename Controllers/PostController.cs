using Roastío.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture
{
  public class PostController : Controller
  {
    private MyContext DbContext;
    public PostController(MyContext context)
    {
      DbContext = context;
    }



    public IActionResult BlogNavLink()
    {
      MainModel dashboard = new MainModel();
      dashboard.UsersPost = DbContext.Posts.Include(userposted => userposted.UserPosted).Include(vote => vote.Votes).ToList();
      return View("success", dashboard);
    }



    [HttpGet("success")]
    public IActionResult success()
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        return RedirectToAction("Index", "Home");
      }
      MainModel dashboard = new MainModel();
      dashboard.UsersPost = DbContext.Posts.Include(userposted => userposted.UserPosted).Include(vote => vote.Votes).ToList();
      return View(dashboard);
    }


    [HttpPost("Post/new")]
    public IActionResult newPost(MainModel newPost)
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        // return RedirectToAction("Index", "Home");
        MainModel dashboardto = new MainModel();
        dashboardto.UsersPost = DbContext.Posts.Include(userposted => userposted.UserPosted).Include(vote => vote.Votes).ToList();
        ModelState.AddModelError("PostToPost.Content", "Login required for submission");
        return View("success", dashboardto);
      }
      if (ModelState.IsValid)
      {
        User user = DbContext.Users.FirstOrDefault(userfromdb => userfromdb.UserId == HttpContext.Session.GetInt32("userId"));
        newPost.PostToPost.UserPosted = user;
        DbContext.Add(newPost.PostToPost);
        DbContext.SaveChanges();
        return RedirectToAction("success");
      }
      MainModel dashboard = new MainModel();
      dashboard.UsersPost = DbContext.Posts.Include(userposted => userposted.UserPosted).Include(vote => vote.Votes).ToList();
      return View("success", dashboard);
    }


    [HttpPost("Post/delete/{pId}")]
    public IActionResult delete(int pId)
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        return RedirectToAction("Index", "Home");
      }
      Post postToDelete = DbContext.Posts.FirstOrDefault(post => post.PostId == pId);
      DbContext.Remove(postToDelete);
      DbContext.SaveChanges();
      return RedirectToAction("success");
    }


    [HttpGet("Post/edit/{pId}")]
    public IActionResult edit(int pId)
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        return RedirectToAction("Index", "Home");
      }
      Post postToEdit = DbContext.Posts.FirstOrDefault(post => post.PostId == pId);
      return View(postToEdit);
    }


    [HttpPost("Post/edit/{pId}")]
    public IActionResult editPost(int pId, Post postFromForm)
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        return RedirectToAction("Index", "Home");
      }
      Post postToEdit = DbContext.Posts.FirstOrDefault(post => post.PostId == pId);
      if (ModelState.IsValid)
      {
        postToEdit.Content = postFromForm.Content;
        postToEdit.UpdatedAt = DateTime.Now;
        DbContext.SaveChanges();
        return RedirectToAction("success");
      }
      return View("edit", postToEdit);
    }


    [HttpPost("Vote")]
    public IActionResult Vote(int pId, bool vote)
    {
      if (HttpContext.Session.GetInt32("userId") == null)
      {
        return RedirectToAction("Index", "Home");
      }
      Vote isVoted = DbContext.Votes.Where(post => post.PostId == pId).FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("userId"));
      if (isVoted == null)
      {
        Vote newVote = new Vote();
        newVote.IsUpvote = vote;
        newVote.PostId = pId;
        newVote.UserId = (int)HttpContext.Session.GetInt32("userId");
        DbContext.Add(newVote);
        DbContext.SaveChanges();
        return RedirectToAction("success");
      }
      if (isVoted.IsUpvote == vote)
      {
        DbContext.Remove(isVoted);
      }
      else
      {
        isVoted.IsUpvote = vote;
        //DbContext.Update(isVoted);
      }
      DbContext.SaveChanges();
      return RedirectToAction("success");
    }
  }
}
