using DeckofCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckofCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        //this creates an object and refernce to the API calls
        DeckOfCardsDAL deckDAL = new DeckOfCardsDAL();

        //create a new deck object and call the deck view with the objects data
        public IActionResult Deck()
        {
            Deck d = deckDAL.GetDeckAPI();
            return View(d);
        }

        //this method will call the Draw view, passing a deck Id
        //to the hand object.
        public IActionResult Draw(string deckId)
        {
            
            Hand c = deckDAL.GetHand(deckId);
            return View(c);
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
