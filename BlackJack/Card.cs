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
		string cardstring;

		// constructor
		public Card (string suit, string rank, int level)
		{
			this.suit = suit;
			this.rank = rank;
			this.level = level;

			// get ready...assigning numerical rank and cardstring for every possibility
			switch(rank)
			{
			case("ace"):
				numericalRank = 1; // aces are always ones by default
				if (suit == "spades")
					cardstring = "ace_of_spades.png";
				else if (suit == "clubs")
					cardstring = "ace_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "ace_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "ace_of_diamonds.png";
				break;
			case("two"):
				numericalRank = 2;
				if (suit == "spades")
					cardstring = "2_of_spades.png";
				else if (suit == "clubs")
					cardstring = "2_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "2_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "2_of_diamonds.png";
				break;
			case("three"):
				numericalRank = 3;
				if (suit == "spades")
					cardstring = "3_of_spades.png";
				else if (suit == "clubs")
					cardstring = "3_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "3_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "3_of_diamonds.png";
				break;
			case("four"):
				numericalRank = 4;
				if (suit == "spades")
					cardstring = "4_of_spades.png";
				else if (suit == "clubs")
					cardstring = "4_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "4_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "4_of_diamonds.png";
				break;
			case("five"):
				numericalRank = 5;
				if (suit == "spades")
					cardstring = "5_of_spades.png";
				else if (suit == "clubs")
					cardstring = "5_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "5_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "5_of_diamonds.png";
				break;
			case("six"):
				numericalRank = 6;
				if (suit == "spades")
					cardstring = "6_of_spades.png";
				else if (suit == "clubs")
					cardstring = "6_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "6_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "6_of_diamonds.png";
				break;
			case("seven"):
				numericalRank = 7;
				if (suit == "spades")
					cardstring = "7_of_spades.png";
				else if (suit == "clubs")
					cardstring = "7_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "7_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "7_of_diamonds.png";
				break;
			case("eight"):
				numericalRank = 8;
				if (suit == "spades")
					cardstring = "8_of_spades.png";
				else if (suit == "clubs")
					cardstring = "8_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "8_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "8_of_diamonds.png";
				break;
			case("nine"):
				numericalRank = 9;
				if (suit == "spades")
					cardstring = "9_of_spades.png";
				else if (suit == "clubs")
					cardstring = "9_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "9_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "9_of_diamonds.png";
				break;
			case("ten"):
				numericalRank = 10;
				if (suit == "spades")
					cardstring = "10_of_spades.png";
				else if (suit == "clubs")
					cardstring = "10_of_clubs.png";
				else if (suit == "hearts")
					cardstring = "10_of_hearts.png";
				else if (suit == "diamonds")
					cardstring = "10_of_diamonds.png";
				break;
			case("jack"):
				numericalRank = 10;
				if (suit == "spades")
					cardstring = "jack_of_spades2.png";
				else if (suit == "clubs")
					cardstring = "jack_of_clubs2.png";
				else if (suit == "hearts")
					cardstring = "jack_of_hearts2.png";
				else if (suit == "diamonds")
					cardstring = "jack_of_diamonds2.png";
				break;
			case("queen"):
				numericalRank = 10;
				if (suit == "spades")
					cardstring = "queen_of_spades2.png";
				else if (suit == "clubs")
					cardstring = "queen_of_clubs2.png";
				else if (suit == "hearts")
					cardstring = "queen_of_hearts2.png";
				else if (suit == "diamonds")
					cardstring = "queen_of_diamonds2.png";
				break;
			case("king"):
				numericalRank = 10;
				if (suit == "spades")
					cardstring = "king_of_spades2.png";
				else if (suit == "clubs")
					cardstring = "king_of_clubs2.png";
				else if (suit == "hearts")
					cardstring = "king_of_hearts2.png";
				else if (suit == "diamonds")
					cardstring = "king_of_diamonds2.png";
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

		public string getCardString()
		{
			return this.cardstring;
		}

		// single setter function for ace test
		public void setNumericalRank(int newNumericalRank)
		{
			// make sure only an ace can be set to 1 or 11.
			if(this.rank == "ace" && (numericalRank == 1 || numericalRank == 11))
			{
				this.numericalRank = newNumericalRank;
			}
			else
			{
				Console.Out.WriteLine("setNumericalRank error: " + this.getRank() + " of " + this.getSuit() + " to " + newNumericalRank);
			}
		}
	}
}

