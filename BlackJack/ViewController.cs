using System;
using System.Threading.Tasks;
using UIKit;

// TODO(kfcampbell):
// 

namespace BlackJack
{
	public partial class ViewController : UIViewController
	{
		int cardsInHand = 0;
		Card mycard1;
		Card mycard2;
		Card mycard3;
		Card mycard4;
		Card housecard1;
		Card housecard2;
		Card housecard3;
		Card housecard4;
		Deck dealDeck = new Deck();
		int mysum;
		int housesum;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			hitButton.Hidden = true;
			doneButton.Hidden = true;

			myCard3Label.Hidden = true;
			myCard4Label.Hidden = true;
			houseCard3Label.Hidden = true;
			houseCard4Label.Hidden = true;

			Card jack = new Card ("spades", "jack", 10);
			Console.Out.WriteLine("suit: " + jack.getSuit() + ". rank: " + jack.getRank());

			Deck thisDeck = new Deck ();
			Console.Out.WriteLine ("aceSpades: " + thisDeck.aceSpades.getRank () + " " + thisDeck.aceSpades.getSuit () + " "
				+ thisDeck.aceSpades.getNumericalRank());
			thisDeck.removeCard (jack);
			try
			{
				Console.Out.WriteLine ("removed card: " + thisDeck.jackSpades.getRank () + thisDeck.jackSpades.getSuit ());
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine (ex);
			}

			Console.Out.WriteLine ("cards left: " + thisDeck.cardsLeft ());
			Console.Out.WriteLine ("is full: " + thisDeck.fullDeck ());

			Card randCard = thisDeck.dealCard ();
			Console.Out.WriteLine ("rand card: " + randCard.getRank () + " " + randCard.getSuit ());

			// button handlers:
			playButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				firstDeal ();
				playButton.Hidden = true;
			};

			hitButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				hitMe();
			};

			doneButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				hitDealer();
			};

		}

		public async void hitDealer()
		{
			updateCount ();
			if(housesum < 17)
			{
				if(housecard3 == null)
				{
					houseCard3Label.Hidden = false;
					houseCard3Label.Text = "Dealing...";
					await Task.Delay (2500);
					housecard3 = dealDeck.dealCard ();
					Console.Out.WriteLine ("housecard3: " + housecard3.getRank () + " of " + housecard3.getSuit ());
					houseCard3Label.Text = housecard3.getRank () + " of " + housecard3.getSuit ();
					await Task.Delay (1000);
					if(checkHouseBust())
					{
						/*var alert = UIAlertController.Create("Whoa Whoa Whoa.", "The house busted! \n On a "
							+ housecard3.getRank() + " of " + housecard3.getSuit(), UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :)", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);*/
					}
				}
				updateCount ();
				Console.Out.WriteLine ("housesum: " + housesum + ". mysum: " + mysum);
				if(housecard4 == null && housesum < 17)
				{
					houseCard4Label.Hidden = false;
					houseCard4Label.Text = "Dealing...";
					await Task.Delay (2500);
					housecard4 = dealDeck.dealCard ();
					Console.Out.WriteLine ("housecard4: " + housecard4.getRank () + " of " + housecard4.getSuit ());
					houseCard4Label.Text = housecard4.getRank () + " of " + housecard4.getSuit ();
					await Task.Delay (1000);
					if(checkHouseBust())
					{
						/*var alert = UIAlertController.Create("Whoa Whoa Whoa.", "The house busted! \n On a "
							+ housecard4.getRank() + " of " + housecard4.getSuit(), UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :)", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);*/
					}
				}
			}
			updateCount ();
			checkWinner ();
		}

		public async void hitMe()
		{
			if(cardsInHand == 4)
			{
				var alert = UIAlertController.Create("Whoa Whoa Whoa.", "You can't hit now, jackass.", UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			else
			{
				if(mycard3 == null)
				{
					myCard3Label.Hidden = false;
					myCard3Label.Text = "Dealing...";
					await Task.Delay (2500);
					mycard3 = dealDeck.dealCard ();
					Console.Out.WriteLine ("mycard3: " + mycard3.getRank () + " of " + mycard3.getSuit ());
					myCard3Label.Text = mycard3.getRank () + " of " + mycard3.getSuit ();
					
					if(checkBust())
					{
						var alert = UIAlertController.Create("Whoa Whoa Whoa.", "You busted! \n" +
							"On a " + mycard3.getRank() + " of " + mycard3.getSuit(), UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :(", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);
					}
				}
				else if(mycard4 == null)
				{
					myCard4Label.Hidden = false;
					myCard4Label.Text = "Dealing...";
					await Task.Delay (2500);
					mycard4 = dealDeck.dealCard ();
					Console.Out.WriteLine ("mycard4: " + mycard4.getRank () + " of " + mycard4.getSuit ());
					myCard4Label.Text = mycard4.getRank () + " of " + mycard4.getSuit ();

					// could refactor into its own function
					if(checkBust())
					{
						var alert = UIAlertController.Create("Whoa Whoa Whoa.", "You busted! \n" +
							"On a " + mycard4.getRank() + " of " + mycard4.getSuit(), UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :(", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);
					}
				}
			}
		}

		public bool checkHouseBust()
		{
			updateCount ();
			Console.Out.WriteLine ("checkHouseBust() entered");

			housesum = 0;
			housesum += housecard1.getNumericalRank();
			housesum += housecard2.getNumericalRank();

			Console.Out.WriteLine ("checkbust sums completed " + mysum);

			try
			{
				housesum += housecard3.getNumericalRank();
				housesum += housecard4.getNumericalRank();
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("housecard3 or 4 seems to be null: " + ex.ToString ());
			}

			if(housesum > 21)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool checkBust()
		{
			updateCount ();
			Console.Out.WriteLine ("checkBust() entered");

			mysum = 0;
			mysum += mycard1.getNumericalRank();
			mysum += mycard2.getNumericalRank();

			Console.Out.WriteLine ("checkbust sums completed " + mysum);

			try
			{
				mysum += mycard3.getNumericalRank();
				mysum += mycard4.getNumericalRank();
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("mycard3 or 4 seems to be null: " + ex.ToString ());
			}

			if(mysum > 21)
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		private void updateCount()
		{
			mysum = 0;
			housesum = 0;
			mysum += mycard1.getNumericalRank ();
			mysum += mycard2.getNumericalRank ();

			try
			{
				mysum += mycard3.getNumericalRank();
				mysum += mycard4.getNumericalRank();
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("updateCount error. One or more of your cards is null. Count: " + mysum);
				Console.Out.WriteLine ("Error: " + ex.ToString ());
			}

			housesum += housecard1.getNumericalRank ();
			housesum += housecard2.getNumericalRank ();

			try
			{
				housesum += housecard3.getNumericalRank();
				housesum += housecard4.getNumericalRank();
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine (ex.ToString ());
			}

			myCardsLabel.Text = "Your Cards (sum " + mysum + ")";
			houseCardsLabel.Text = "Dealer's Cards (sum " + housesum + ")";
		}

		public string printCards()
		{
			var cardstring = "";
			cardstring += "Your cards: \n";
			try
			{
				cardstring += mycard1.getRank() + " of " + mycard1.getSuit() + "\n";
				cardstring += mycard2.getRank() + " of " + mycard2.getSuit() + "\n";
				cardstring += mycard3.getRank() + " of " + mycard3.getSuit() + "\n";
				cardstring += mycard4.getRank() + " of " + mycard4.getSuit() + "\n";
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("my cardstring error: " + ex.ToString ());
			}
			cardstring += "House cards: \n";
			try
			{
				cardstring += housecard1.getRank() + " of " + housecard1.getSuit() + "\n";
				cardstring += housecard2.getRank() + " of " + housecard2.getSuit() + "\n";
				cardstring += housecard3.getRank() + " of " + housecard3.getSuit() + "\n";
				cardstring += housecard4.getRank() + " of " + housecard4.getSuit() + "\n";
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("house cardstring error: " + ex.ToString ());
			}
			return cardstring;
		}

		public async void checkWinner()
		{
			updateCount ();
			await Task.Delay (2000);
			updateCount ();
			if (housesum > mysum && !checkHouseBust()) 
			{
				Console.Out.WriteLine ("House wins!");
				resultLabel.Text = "House wins!";

				var alert = UIAlertController.Create("House Wins!", "You can't beat the man." +
					"\n " + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Okay :(", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			} 
			else if (housesum < mysum && !checkBust ()) 
			{
				Console.Out.WriteLine ("You win!");
				resultLabel.Text = "You win!";

				var alert = UIAlertController.Create("You Win!", "Aww yeah bitch." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Alright!", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);

			} else if (housesum == mysum) 
			{
				Console.Out.WriteLine ("Push!");
				resultLabel.Text = "It was a push!";

				var alert = UIAlertController.Create("It was a push!", "Bummer, dude." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			else if(housesum > mysum && checkHouseBust())
			{
				Console.Out.WriteLine ("You win!");
				resultLabel.Text = "You win!";

				var alert = UIAlertController.Create("You Win!", "Aww yeah bitch." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Alright!", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			else if(housesum < mysum && checkBust())
			{
				Console.Out.WriteLine ("You win!");
				resultLabel.Text = "You win!";

				var alert = UIAlertController.Create("You Win!", "Aww yeah bitch." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Alright!", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			clearUI ();
		}

		public void clearUI()
		{
			dealDeck = null;
			dealDeck = new Deck ();

			mycard3 = null;
			mycard4 = null;
			housecard3 = null;
			housecard4 = null;

			myCard3Label.Hidden = true;
			myCard4Label.Hidden = true;
			houseCard3Label.Hidden = true;
			houseCard4Label.Hidden = true;
			hitButton.Hidden = true;
			doneButton.Hidden = true;

			myCard1Label.Text = "Card One";
			myCard2Label.Text = "Card Two";
			houseCard1Label.Text = "Card One";
			houseCard2Label.Text = "Card Two";

			myCardsLabel.Text = "Your Cards";
			houseCardsLabel.Text = "Dealer's Cards";

			playButton.Hidden = false;
		}

		public async void firstDeal()
		{
			// alright, deal me in.
			mycard1 = dealDeck.dealCard ();
			myCard1Label.Text = mycard1.getRank () + " of " + mycard1.getSuit ();
			myCard2Label.Text = "Dealing...";
			houseCard1Label.Text = "Dealing...";
			houseCard2Label.Text = "Dealing...";
			await Task.Delay (2500);
			mycard2 = dealDeck.dealCard ();
			myCard2Label.Text = mycard2.getRank () + " of " + mycard2.getSuit ();
			cardsInHand = 2;
			await Task.Delay (2500);

			// deal the dealer in
			housecard1 = dealDeck.dealCard ();
			houseCard1Label.Text = housecard1.getRank () + " of " + housecard1.getSuit ();
			await Task.Delay (2500);
			housecard2 = dealDeck.dealCard ();
			houseCard2Label.Text = housecard2.getRank () + " of " + housecard2.getSuit ();

			Console.Out.WriteLine ("mycard1: " + mycard1.getRank () + " " + mycard1.getSuit ());
			Console.Out.WriteLine ("mycard2: " + mycard2.getRank () + " " + mycard2.getSuit ());

			int mycardsum = mycard1.getNumericalRank () + mycard2.getNumericalRank ();
			Console.Out.WriteLine ("my cards summed: " + mycardsum);

			Console.Out.WriteLine ("housecard1: " + housecard1.getRank () + " " + housecard1.getSuit ());
			Console.Out.WriteLine ("housecard2: " + housecard2.getRank () + " " + housecard2.getSuit ());
			int housecardsum = housecard1.getNumericalRank () + housecard2.getNumericalRank ();
			Console.Out.WriteLine ("house cards summed: " + housecardsum);

			updateCount ();

			hitButton.Hidden = false;
			doneButton.Hidden = false;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

