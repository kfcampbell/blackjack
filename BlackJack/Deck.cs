using System;

namespace BlackJack
{
	public class Deck
	{
		// member variables
		int remaining;
		bool isFull;

		// cards are public to avoid getter and setters for each. i know, i know...
		// spades suit
		public Card aceSpades;
		public Card twoSpades;
		public Card threeSpades;
		public Card fourSpades;
		public Card fiveSpades;
		public Card sixSpades;
		public Card sevenSpades;
		public Card eightSpades;
		public Card nineSpades;
		public Card tenSpades;
		public Card jackSpades;
		public Card queenSpades;
		public Card kingSpades;

		// clubs suit
		public Card aceClubs;
		public Card twoClubs;
		public Card threeClubs;
		public Card fourClubs;
		public Card fiveClubs;
		public Card sixClubs;
		public Card sevenClubs;
		public Card eightClubs;
		public Card nineClubs;
		public Card tenClubs;
		public Card jackClubs;
		public Card queenClubs;
		public Card kingClubs;

		// diamonds suit
		public Card aceDiamonds;
		public Card twoDiamonds;
		public Card threeDiamonds;
		public Card fourDiamonds;
		public Card fiveDiamonds;
		public Card sixDiamonds;
		public Card sevenDiamonds;
		public Card eightDiamonds;
		public Card nineDiamonds;
		public Card tenDiamonds;
		public Card jackDiamonds;
		public Card queenDiamonds;
		public Card kingDiamonds;

		// hearts suit
		public Card aceHearts;
		public Card twoHearts;
		public Card threeHearts;
		public Card fourHearts;
		public Card fiveHearts;
		public Card sixHearts;
		public Card sevenHearts;
		public Card eightHearts;
		public Card nineHearts;
		public Card tenHearts;
		public Card jackHearts;
		public Card queenHearts;
		public Card kingHearts;

		// constructor
		public Deck ()
		{
			this.remaining = 52;
			this.isFull = true;

			// initialize the entire deck...
			// start with the spades as per usual
			this.aceSpades = new Card ("spades", "ace");
			this.twoSpades = new Card ("spades", "two");
			this.threeSpades = new Card ("spades", "three");
			this.fourSpades = new Card ("spades", "four");
			this.fiveSpades = new Card ("spades", "five");
			this.sixSpades = new Card ("spades", "six");
			this.sevenSpades = new Card ("spades", "seven");
			this.eightSpades = new Card ("spades", "eight");
			this.nineSpades = new Card ("spades", "nine");
			this.tenSpades = new Card ("spades", "ten");
			this.jackSpades = new Card ("spades", "jack");
			this.queenSpades = new Card ("spades", "queen");
			this.kingSpades = new Card ("spades", "king");

			// initialize the clubs
			this.aceClubs = new Card ("clubs", "ace");
			this.twoClubs = new Card ("clubs", "two");
			this.threeClubs = new Card ("clubs", "three");
			this.fourClubs = new Card ("clubs", "four");
			this.fiveClubs = new Card ("clubs", "five");
			this.sixClubs = new Card ("clubs", "six");
			this.sevenClubs = new Card ("clubs", "seven");
			this.eightClubs = new Card ("clubs", "eight");
			this.nineClubs = new Card ("clubs", "nine");
			this.tenClubs = new Card ("clubs", "ten");
			this.jackClubs = new Card ("clubs", "jack");
			this.queenClubs = new Card ("clubs", "queen");
			this.kingClubs = new Card ("clubs", "king");

			// then the diamonds
			this.aceDiamonds = new Card ("diamonds", "ace");
			this.twoDiamonds = new Card ("diamonds", "two");
			this.threeDiamonds = new Card ("diamonds", "three");
			this.fourDiamonds = new Card ("diamonds", "four");
			this.fiveDiamonds = new Card ("diamonds", "five");
			this.sixDiamonds = new Card ("diamonds", "six");
			this.sevenDiamonds = new Card ("diamonds", "seven");
			this.eightDiamonds = new Card ("diamonds", "eight");
			this.nineDiamonds = new Card ("diamonds", "nine");
			this.tenDiamonds = new Card ("diamonds", "ten");
			this.jackDiamonds = new Card ("diamonds", "jack");
			this.queenDiamonds = new Card ("diamonds", "queen");
			this.kingDiamonds = new Card ("diamonds", "king");

			// finally the hearts
			this.aceHearts = new Card ("hearts", "ace");
			this.twoHearts = new Card ("hearts", "two");
			this.threeHearts = new Card ("hearts", "three");
			this.fourHearts = new Card ("hearts", "four");
			this.fiveHearts = new Card ("hearts", "five");
			this.sixHearts = new Card ("hearts", "six");
			this.sevenHearts = new Card ("hearts", "seven");
			this.eightHearts = new Card ("hearts", "eight");
			this.nineHearts = new Card ("hearts", "nine");
			this.tenHearts = new Card ("hearts", "ten");
			this.jackHearts = new Card ("hearts", "jack");
			this.queenHearts = new Card ("hearts", "queen");
			this.kingHearts = new Card ("hearts", "king");
		}

		// returns how many cards are left in the deck
		public int cardsLeft()
		{
			return this.remaining;
		}

		public bool fullDeck()
		{
			return this.isFull;
		}

		// remove a card from the deck (in the case of being dealt)
		public void removeCard(Card card)
		{
			if(card.getSuit() == "spades")
			{
				switch(card.getRank())
				{
				case("ace"):
					this.aceSpades = null;
					break;
				case("two"):
					this.twoSpades = null;
					break;
				case("three"):
					this.threeSpades = null;
					break;
				case("four"):
					this.fourSpades = null;
					break;
				case("five"):
					this.fiveSpades = null;
					break;
				case("six"):
					this.sixSpades = null;
					break;
				case("seven"):
					this.sevenSpades = null;
					break;
				case("eight"):
					this.eightSpades = null;
					break;
				case("nine"):
					this.nineSpades = null;
					break;
				case("ten"):
					this.tenSpades = null;
					break;
				case("jack"):
					this.jackSpades = null;
					break;
				case("queen"):
					this.queenSpades = null;
					break;
				case("king"):
					this.kingSpades = null;
					break;
				default:
					Console.Out.WriteLine ("Remove Card Error: " + card.getRank () + " " + card.getSuit ());
					break;
				}
			}
			else if(card.getSuit() == "clubs")
			{
				switch(card.getRank())
				{
				case("ace"):
					this.aceClubs = null;
					break;
				case("two"):
					this.twoClubs = null;
					break;
				case("three"):
					this.threeClubs = null;
					break;
				case("four"):
					this.fourClubs = null;
					break;
				case("five"):
					this.fiveClubs = null;
					break;
				case("six"):
					this.sixClubs = null;
					break;
				case("seven"):
					this.sevenClubs = null;
					break;
				case("eight"):
					this.eightClubs = null;
					break;
				case("nine"):
					this.nineClubs = null;
					break;
				case("ten"):
					this.tenClubs = null;
					break;
				case("jack"):
					this.jackClubs = null;
					break;
				case("queen"):
					this.queenClubs = null;
					break;
				case("king"):
					this.kingClubs = null;
					break;
				default:
					Console.Out.WriteLine ("Remove Card Error: " + card.getRank () + " " + card.getSuit ());
					break;
				}
			}
			else if(card.getSuit() == "diamonds")
			{
				switch(card.getRank())
				{
				case("ace"):
					this.aceDiamonds = null;
					break;
				case("two"):
					this.twoDiamonds = null;
					break;
				case("three"):
					this.threeDiamonds = null;
					break;
				case("four"):
					this.fourDiamonds = null;
					break;
				case("five"):
					this.fiveDiamonds = null;
					break;
				case("six"):
					this.sixDiamonds = null;
					break;
				case("seven"):
					this.sevenDiamonds = null;
					break;
				case("eight"):
					this.eightDiamonds = null;
					break;
				case("nine"):
					this.nineDiamonds = null;
					break;
				case("ten"):
					this.tenDiamonds = null;
					break;
				case("jack"):
					this.jackDiamonds = null;
					break;
				case("queen"):
					this.queenDiamonds = null;
					break;
				case("king"):
					this.kingDiamonds = null;
					break;
				default:
					Console.Out.WriteLine ("Remove Card Error: " + card.getRank () + " " + card.getSuit ());
					break;
				}
			}
			else if(card.getSuit() == "hearts")
			{
				switch(card.getRank())
				{
				case("ace"):
					this.aceHearts = null;
					break;
				case("two"):
					this.twoHearts = null;
					break;
				case("three"):
					this.threeHearts = null;
					break;
				case("four"):
					this.fourHearts = null;
					break;
				case("five"):
					this.fiveHearts = null;
					break;
				case("six"):
					this.sixHearts = null;
					break;
				case("seven"):
					this.sevenHearts = null;
					break;
				case("eight"):
					this.eightHearts = null;
					break;
				case("nine"):
					this.nineHearts = null;
					break;
				case("ten"):
					this.tenHearts = null;
					break;
				case("jack"):
					this.jackHearts = null;
					break;
				case("queen"):
					this.queenHearts = null;
					break;
				case("king"):
					this.kingHearts = null;
					break;
				default:
					Console.Out.WriteLine ("Rank Remove Card Error: " + card.getRank () + " " + card.getSuit ());
					break;
				}
			}
			else
			{
				Console.Out.WriteLine ("Suit Remove Card Error: " + card.getRank() + " " + card.getSuit ());
			}

			this.isFull = false;
			this.remaining--;
		}

		// function to pick a random card and deal it
		// eventually this should return a card
		public void dealCard()
		{
			Random random = new Random ();
			int randCardRank = random.Next(52); // random number between 0 and 51 to use when picking a random card
			Console.Out.WriteLine ("random number: " + randCardRank);
		}
	}
}

