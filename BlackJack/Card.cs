using System;

//TODO(kfcampbell):
// 1. Give each card a numerical rank to compare with based upon the string rank (use a switch case)

namespace BlackJack
{
	public class Card
	{
		// member variables
		string suit;
		string rank;
		int numericalRank;
		int level;

		// constructor
		public Card (string suit, string rank, int level)
		{
			this.suit = suit;
			this.rank = rank;
			this.level = level;

			switch(rank)
			{
			case("ace"):
				numericalRank = 1; // aces are always ones for now...
				break;
			case("two"):
				numericalRank = 2;
				break;
			case("three"):
				numericalRank = 3;
				break;
			case("four"):
				numericalRank = 4;
				break;
			case("five"):
				numericalRank = 5;
				break;
			case("six"):
				numericalRank = 6;
				break;
			case("seven"):
				numericalRank = 7;
				break;
			case("eight"):
				numericalRank = 8;
				break;
			case("nine"):
				numericalRank = 9;
				break;
			case("ten"):
				numericalRank = 10;
				break;
			case("jack"):
				numericalRank = 10;
				break;
			case("queen"):
				numericalRank = 10;
				break;
			case("king"):
				numericalRank = 10;
				break;
			default:
				Console.Out.WriteLine ("Card error assigning rank: " + suit + " " + rank);
				break;
			}
		}

		// getter functions
		public string getSuit()
		{
			return this.suit;
		}

		public string getRank()
		{
			return this.rank;
		}

		public int getNumericalRank()
		{
			return this.numericalRank;
		}

		public int getLevel()
		{
			return this.level;
		}
	}
}

