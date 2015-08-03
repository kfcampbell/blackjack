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
			this.aceSpades = new Card ("spades", "ace", 0);
			this.twoSpades = new Card ("spades", "two", 1);
			this.threeSpades = new Card ("spades", "three", 2);
			this.fourSpades = new Card ("spades", "four", 3);
			this.fiveSpades = new Card ("spades", "five", 4);
			this.sixSpades = new Card ("spades", "six", 5);
			this.sevenSpades = new Card ("spades", "seven", 6);
			this.eightSpades = new Card ("spades", "eight", 7);
			this.nineSpades = new Card ("spades", "nine", 8);
			this.tenSpades = new Card ("spades", "ten", 9);
			this.jackSpades = new Card ("spades", "jack", 10);
			this.queenSpades = new Card ("spades", "queen", 11);
			this.kingSpades = new Card ("spades", "king", 12);

			// initialize the clubs
			this.aceClubs = new Card ("clubs", "ace", 13);
			this.twoClubs = new Card ("clubs", "two", 14);
			this.threeClubs = new Card ("clubs", "three", 15);
			this.fourClubs = new Card ("clubs", "four", 16);
			this.fiveClubs = new Card ("clubs", "five", 17);
			this.sixClubs = new Card ("clubs", "six", 18);
			this.sevenClubs = new Card ("clubs", "seven", 19);
			this.eightClubs = new Card ("clubs", "eight", 20);
			this.nineClubs = new Card ("clubs", "nine", 21);
			this.tenClubs = new Card ("clubs", "ten", 22);
			this.jackClubs = new Card ("clubs", "jack", 23);
			this.queenClubs = new Card ("clubs", "queen", 24);
			this.kingClubs = new Card ("clubs", "king", 25);

			// then the diamonds
			this.aceDiamonds = new Card ("diamonds", "ace", 26);
			this.twoDiamonds = new Card ("diamonds", "two", 27);
			this.threeDiamonds = new Card ("diamonds", "three", 28);
			this.fourDiamonds = new Card ("diamonds", "four", 29);
			this.fiveDiamonds = new Card ("diamonds", "five", 30);
			this.sixDiamonds = new Card ("diamonds", "six", 31);
			this.sevenDiamonds = new Card ("diamonds", "seven", 32);
			this.eightDiamonds = new Card ("diamonds", "eight", 33);
			this.nineDiamonds = new Card ("diamonds", "nine", 34);
			this.tenDiamonds = new Card ("diamonds", "ten", 35);
			this.jackDiamonds = new Card ("diamonds", "jack", 36);
			this.queenDiamonds = new Card ("diamonds", "queen", 37);
			this.kingDiamonds = new Card ("diamonds", "king", 38);

			// finally the hearts
			this.aceHearts = new Card ("hearts", "ace", 39);
			this.twoHearts = new Card ("hearts", "two", 40);
			this.threeHearts = new Card ("hearts", "three", 41);
			this.fourHearts = new Card ("hearts", "four", 42);
			this.fiveHearts = new Card ("hearts", "five", 43);
			this.sixHearts = new Card ("hearts", "six", 44);
			this.sevenHearts = new Card ("hearts", "seven", 45);
			this.eightHearts = new Card ("hearts", "eight", 46);
			this.nineHearts = new Card ("hearts", "nine", 47);
			this.tenHearts = new Card ("hearts", "ten", 48);
			this.jackHearts = new Card ("hearts", "jack", 49);
			this.queenHearts = new Card ("hearts", "queen", 50);
			this.kingHearts = new Card ("hearts", "king", 51);
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
		public Card dealCard()
		{
			Random random = new Random ();
			int randCardRank = random.Next(52); // random number between 0 and 51 to use when picking a random card
			//Console.Out.WriteLine ("random number: " + randCardRank);

			Card returnCard = new Card("the angel's card", "king of heaven", 777);

			try
			{
				// now pick a card in the deck and make it null
				// this is gonna be a nightmare
				switch(randCardRank)
				{
				case 0:
					this.aceSpades = null;
					returnCard = new Card ("spades", "ace", 0);
					break;
				case 1:
					this.twoSpades = null;
					returnCard = new Card ("spades", "two", 1);
					break;
				case 2:
					this.threeSpades = null;
					returnCard = new Card ("spades", "three", 2);
					break;
				case 3:
					this.fourSpades = null;
					returnCard = new Card ("spades", "four", 3);
					break;
				case 4:
					this.fiveSpades = null;
					returnCard = new Card ("spades", "five", 4);
					break;
				case 5:
					this.sixSpades = null;
					returnCard = new Card ("spades", "six", 5);
					break;
				case 6:
					this.sevenSpades = null;
					returnCard = new Card ("spades", "seven", 6);
					break;
				case 7:
					this.eightSpades = null;
					returnCard = new Card ("spades", "eight", 7);
					break;
				case 8:
					this.nineSpades = null;
					returnCard = new Card ("spades", "nine", 8);
					break;
				case 9:
					this.tenSpades = null;
					returnCard = new Card ("spades", "ten", 9);
					break;
				case 10:
					this.jackSpades = null;
					returnCard = new Card ("spades", "jack", 10);
					break;
				case 11:
					this.queenSpades = null;
					returnCard = new Card ("spades", "queen", 11);
					break;
				case 12:
					this.kingSpades = null;
					returnCard = new Card ("spades", "king", 12);
					break;
				case 13:
					this.aceClubs = null;
					returnCard = new Card ("clubs", "ace", 13);
					break;
				case 14:
					this.twoClubs = null;
					returnCard = new Card ("clubs", "two", 14);
					break;
				case 15:
					this.threeClubs = null;
					returnCard = new Card ("clubs", "three", 15);
					break;
				case 16:
					this.fourClubs = null;
					returnCard = new Card ("clubs", "four", 16);
					break;
				case 17:
					this.fiveClubs = null;
					returnCard = new Card ("clubs", "five", 17);
					break;
				case 18:
					this.sixClubs = null;
					returnCard = new Card ("clubs", "six", 18);
					break;
				case 19:
					this.sevenClubs = null;
					returnCard = new Card ("clubs", "seven", 19);
					break;
				case 20:
					this.eightClubs = null;
					returnCard = new Card ("clubs", "eight", 20);
					break;
				case 21:
					this.nineClubs = null;
					returnCard = new Card ("clubs", "nine", 21);
					break;
				case 22:
					this.tenClubs = null;
					returnCard = new Card ("clubs", "ten", 22);
					break;
				case 23:
					this.jackClubs = null;
					returnCard = new Card ("clubs", "jack", 23);
					break;
				case 24:
					this.queenClubs = null;
					returnCard = new Card ("clubs", "queen", 24);
					break;
				case 25:
					this.kingClubs = null;
					returnCard = new Card ("clubs", "king", 25);
					break;
				case 26:
					this.aceDiamonds = null;
					returnCard = new Card ("diamonds", "ace", 26);
					break;
				case 27:
					this.twoDiamonds = null;
					returnCard = new Card ("diamonds", "two", 27);
					break;
				case 28:
					this.threeDiamonds = null;
					returnCard = new Card ("diamonds", "three", 28);
					break;
				case 29:
					this.fourDiamonds = null;
					returnCard = new Card ("diamonds", "four", 29);
					break;
				case 30:
					this.fiveDiamonds = null;
					returnCard = new Card ("diamonds", "five", 30);
					break;
				case 31:
					this.sixDiamonds = null;
					returnCard = new Card ("diamonds", "six", 31);
					break;
				case 32:
					this.sevenDiamonds = null;
					returnCard = new Card ("diamonds", "seven", 32);
					break;
				case 33:
					this.eightDiamonds = null;
					returnCard = new Card ("diamonds", "eight", 33);
					break;
				case 34:
					this.nineDiamonds = null;
					returnCard = new Card ("diamonds", "nine", 34);
					break;
				case 35:
					this.tenDiamonds = null;
					returnCard = new Card ("diamonds", "ten", 35);
					break;
				case 36:
					this.jackDiamonds = null;
					returnCard = new Card ("diamonds", "jack", 36);
					break;
				case 37:
					this.queenDiamonds = null;
					returnCard = new Card ("diamonds", "queen", 37);
					break;
				case 38:
					this.kingDiamonds = null;
					returnCard = new Card ("diamonds", "king", 38);
					break;
				case 39:
					this.aceHearts = null;
					returnCard = new Card ("hearts", "ace", 39);
					break;
				case 40:
					this.twoHearts = null;
					returnCard = new Card ("hearts", "two", 40);
					break;
				case 41:
					this.threeHearts = null;
					returnCard = new Card ("hearts", "three", 41);
					break;
				case 42:
					this.fourHearts = null;
					returnCard = new Card ("hearts", "four", 42);
					break;
				case 43:
					this.fiveHearts = null;
					returnCard = new Card ("hearts", "five", 43);
					break;
				case 44:
					this.sixHearts = null;
					returnCard = new Card ("hearts", "six", 44);
					break;
				case 45:
					this.sevenHearts = null;
					returnCard = new Card ("hearts", "seven", 45);
					break;
				case 46:
					this.eightHearts = null;
					returnCard = new Card ("hearts", "eight", 46);
					break;
				case 47:
					this.nineHearts = null;
					returnCard = new Card ("hearts", "nine", 47);
					break;
				case 48:
					this.tenHearts = null;
					returnCard = new Card ("hearts", "ten", 48);
					break;
				case 49:
					this.jackHearts = null;
					returnCard = new Card ("hearts", "jack", 49);
					break;
				case 50:
					this.queenHearts = null;
					returnCard = new Card ("hearts", "queen", 50);
					break;
				case 51:
					this.kingHearts = null;
					returnCard = new Card ("hearts", "king", 51);
					break;
				default:
					Console.Out.WriteLine ("Random Card Error.");
					returnCard = new Card ("the devil's card", "king of hell", 666);
					break;
				}
				Console.Out.WriteLine("after switch: " + returnCard.getRank() + " " + returnCard.getSuit());
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("Random card error. Card is already null");
				Console.Out.WriteLine ("Error: " + ex.ToString ());
				dealCard ();
			}
			return returnCard;
		}
	}
}

