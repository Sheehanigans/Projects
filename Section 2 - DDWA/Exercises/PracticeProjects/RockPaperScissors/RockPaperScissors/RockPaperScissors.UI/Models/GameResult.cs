using RockPaperScissors.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissors.UI.Models
{
    public class GameResult
    {
        public RPSChoice Player1Result { get; set; }
        public RPSChoice Player2Result { get; set; }
        public int Result { get; set; }
        public string ResultMessage { get; set; }
    }
}