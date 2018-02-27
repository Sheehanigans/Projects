using RockPaperScissors.BLL;
using RockPaperScissors.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockPaperScissors.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shoot(string shoot)
        {
            var model = new GameResult();

            if(shoot == "Rock")
            {
                model.Player1Result = RPSChoice.Rock;
            }
            else if(shoot == "Paper")
            {
                model.Player1Result = RPSChoice.Paper;
            }
            else  if(shoot == "Scissors")
            {
                model.Player1Result = RPSChoice.Scissors;
            }

            int choice = RNG.NextInt(0, 3);

            if(choice == 0)
            {
                model.Player2Result = RPSChoice.Rock;
            }
            else if(choice == 1)
            {
                model.Player2Result = RPSChoice.Paper;
            }
            else if(choice == 2)
            {
                model.Player2Result = RPSChoice.Scissors;
            }

            GameEngine engine = new GameEngine();

            model.Result = engine.CompareThrows(model.Player1Result, model.Player2Result);

            if (model.Result < 0)
            {
                model.ResultMessage = "Player 1 is the winner!";
            }
            else if (model.Result > 0)
            {
                model.ResultMessage = "Player 2 is the winner!";
            }
            else
            {
                model.ResultMessage = "It's a draw!";
            }

            return View(model);
        }
    }
}