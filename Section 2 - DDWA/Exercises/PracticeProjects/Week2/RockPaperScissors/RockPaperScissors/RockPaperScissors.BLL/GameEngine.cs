﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BLL
{
	public class GameEngine
	{
		IChoiceGetter _player1;
		IChoiceGetter _player2;

		public GameEngine(IChoiceGetter player1, IChoiceGetter player2)
		{
			_player1 = player1;
			_player2 = player2;
		}

        public GameEngine() { }

		public RoundResult PlayRound()
		{
			RPSChoice p1Choice = _player1.GetChoice();
			RPSChoice p2Choice = _player2.GetChoice();

			int result = CompareThrows(p1Choice, p2Choice);

			return new RoundResult( p1Choice, p2Choice, result );
		}

		public int CompareThrows(RPSChoice a, RPSChoice b)
		{
			// - a wins
			// 0 tie
			// + b wins

			int toReturn = 0;

			if (a != b)
			{
				switch (a)
				{
					case RPSChoice.Paper:
						toReturn = (b == RPSChoice.Rock) ? -1 : 1;
						break;
					case RPSChoice.Rock:
						toReturn = (b == RPSChoice.Scissors) ? -1 : 1;
						break;
					case RPSChoice.Scissors:
						toReturn = (b == RPSChoice.Paper) ? -1 : 1;
						break;
				}
			}

			return toReturn;
		}
	}
}
