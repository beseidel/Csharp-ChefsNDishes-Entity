using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

// ***********************
// GO TO SESSION FOR VIEWINGSESSION usingViewbag

// for session use this at top of the file
// using Microsoft.AspNetCore.Http;
// *Inside controller methods*
// To store a string in session we use ".SetString"
// The first string passed is the key and the second is the value we want to retrieve later
// HttpContext.Session.SetString("UserName", "Samantha");
// // To retrieve a string from session we use ".GetString"
// string LocalVariable = HttpContext.Session.GetString("UserName");

// // To store an int in session we use ".SetInt32"
// HttpContext.Session.SetInt32("UserAge", 28);
// // To retrieve an int from session we use ".GetInt32"
// int? IntVariable = HttpContext.Session.GetInt32("UserAge"); 

// HttpContext.Session.Clear();
// **********************************

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {


            List<Chef> AllChefs = dbContext.ChefsTable.OrderBy(d => d.CreatedAt)
            .Include(Dish => Dish.CreatedDishes)

            .ToList();
            return View(AllChefs);
        }

        // ***********************


        // [HttpGet("{userId}")]    
        // public IActionResult UserDetails(int userId)
        // {
        //     // Number of messages created by this User
        //     int numMessages = dbContext.Users
        //         // Including Messages, so that we may query on this field
        //         .Include(user => user.CreatedMessages)
        //         // Get a User with userId
        //         .FirstOrDefault(user => user.UserId == userId)
        //         // Now, with a reference to a User object, and access to a User's Messages
        //         // We can get the .Count property of the Messages List
        //         .CreatedMessages.Count;

        //     // User with the longest Message, we can do this in two stages
        //     // First, find the Length of the longest Message
        //     int longestMessageLength = dbContext.Messages.Max(message => message.Content.Length);

        //     // Second, select one User who's CreatedMessages has Any that matches this character count
        //     // Note here that CreatedMessages is a List, and thus can take a LINQ expression: such as .Any()
        //     User userWithLongest = dbContext.Users
        //         .Include(user => user.CreatedMessages)
        //         .FirstOrDefault(user => user.CreatedMessages
        //             .Any(message => message.Content.Length == longestMessageLength));

        //     // Messages NOT related to this User:
        //     // Since this query only requires checking a Message's UserId
        //     // and doesn't require us to check data contained in a Message's Creator
        //     // We can do this without a .Include()
        //     List<Message> unrelatedMessages = dbContext.Messages
        //         .Where(message => message.UserId != userId)
        //         .ToList();

        //     return View();
        // }

        // **********************************************************

        [HttpGet]
        [Route("/dishes")]
        public IActionResult Dishes()
        {

            List<Dish> AllDishes = dbContext.DishesTable.OrderBy(d => d.CreatedAt).Take(20)
            .Include(Chef => Chef.Creator)
            .ToList();

            return View(AllDishes);
        }
        // ***************
        // Example
        // public IActionResult Index()
        // {
        //     List<Message> messagesWithUser = _dbContext.Messages
        //         // populates each Message with its related User object (Creator)
        //         .Include(message => message.Creator)
        //         .ToList();

        //     return View(messagesWithUser);
        // }
        // ***************

        [Route("NewChef")]
        [HttpGet]
        public IActionResult NewChef()
        {
            return View();
        }

        [Route("NewDish")]
        [HttpGet]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.ChefsTable.OrderBy(d => d.CreatedAt).ToList();

            Dish Onedish = new Dish();

            @ViewBag.AllChefs = AllChefs;

            return View(Onedish);
        }

        // Processing Dish
        [Route("NewDish")]
        [HttpPost]
        public IActionResult processdish(Dish submitted_dish)
        {

            if (ModelState.IsValid)
            {

                dbContext.Add(submitted_dish);


                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.ChefsTable.OrderBy(d => d.CreatedAt).ToList();

                @ViewBag.AllChefs = AllChefs;

                return View("NewDish", AllChefs);
            }
        }

        [Route("NewChef")]
        [HttpPost]
        public IActionResult processchef(Chef submitted_chef)
        {

            if (ModelState.IsValid)
            {
                dbContext.Add(submitted_chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }



    }

}

