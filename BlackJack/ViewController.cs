using System;
using System.Threading.Tasks;
using UIKit;

// TODO(kfcampbell):
// 

namespace BlackJack
{
	public partial class ViewController : UIViewController
	{
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

			// set up card views

			// set up button views
			hitButton.Hidden = true;
			doneButton.Hidden = true;

			myCard3Label.Hidden = true;
			myCard4Label.Hidden = true;
			houseCard3Label.Hidden = true;
			houseCard4Label.Hidden = true;

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
				hitButton.Hidden = true;
				doneButton.Hidden = true;
				hitDealer();
			};
		}



		// parameters: card, and an int: 0 = mycard1, 1 = mycard2, 2 = mycard3, 3 = mycard4.
		// 4 = housecard1, 5 = housecard2, 6 = housecard3, 7 = housecard4
		public Card aceTest(Card card, int which)
		{
			Console.Out.WriteLine ("Ace test: which: " + which + ". " + card.getRank () + " of " + card.getSuit ());
			// first some error handling
			if(which < 0 || which > 7)
			{
				Console.Out.WriteLine("AceTest: Not a real card, jackass.");
				return card;
			}

			// now set it to an 11 and update the count
			card.setNumericalRank (11);
			updateCount ();

			// see if an 11 will bust
			if(which == 0 || which == 1 || which == 2 || which == 3)
			{
				if(checkBust())
				{
					card.setNumericalRank (1);
				}
			}
			else if(which == 4 || which == 5 || which == 6 || which == 7)
			{
				if(checkHouseBust())
				{
					card.setNumericalRank (1);
				}
			}
			Console.Out.WriteLine("ace test final result: which: " + which + ". " + card.getRank () + " of " + card.getSuit ());
			return card;
		}

		public async void hitDealer()
		{
			updateCount ();
			if(housesum < 17)
			{
				if(housecard3 == null)
				{
					houseCard3Label.Hidden = false;
					houseImage3.Image = UIImage.FromBundle ("back.png");
					await Task.Delay (2500);
					housecard3 = dealDeck.dealCard ();
					aceTest (housecard1, 4);
					aceTest (housecard2, 5);
					aceTest (housecard3, 6);
					Console.Out.WriteLine ("housecard3: " + housecard3.getRank () + " of " + housecard3.getSuit ());
					houseImage3.Image = UIImage.FromBundle (housecard3.getCardString ());
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
					houseImage4.Image = UIImage.FromBundle ("back.png");
					await Task.Delay (2500);
					housecard4 = dealDeck.dealCard ();
					aceTest (housecard1, 4);
					aceTest (housecard2, 5);
					aceTest (housecard3, 6);
					aceTest (housecard4, 7);
					Console.Out.WriteLine ("housecard4: " + housecard4.getRank () + " of " + housecard4.getSuit ());
					houseCard4Label.Text = housecard4.getRank () + " of " + housecard4.getSuit ();
					houseImage4.Image = UIImage.FromBundle (housecard4.getCardString ());
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
			if(mycard3 != null && mycard4 != null)
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
					myImage3.Image = UIImage.FromBundle ("back.png");
					await Task.Delay (2500);
					mycard3 = dealDeck.dealCard ();
					aceTest (mycard1, 0);
					aceTest (mycard2, 1);
					aceTest (mycard3, 2);
					Console.Out.WriteLine ("mycard3: " + mycard3.getRank () + " of " + mycard3.getSuit ());
					myCard3Label.Text = mycard3.getRank () + " of " + mycard3.getSuit ();
					myImage3.Image = UIImage.FromBundle (mycard3.getCardString ());
					
					if(checkBust())
					{
						var alert = UIAlertController.Create("Whoa Whoa Whoa.", "You busted! \n" +
							"On a " + mycard3.getRank() + " of " + mycard3.getSuit()
							+ "\n Better hope the dealer busts. \n" +
								"He's dealing now. Hurry!", UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :(", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);
						hitButton.Hidden = true;
						doneButton.Hidden = true;
						await Task.Delay (2000);
						hitDealer ();
					}
				}
				else if(mycard4 == null)
				{
					myCard4Label.Hidden = false;
					myImage4.Image = UIImage.FromBundle ("back.png");
					await Task.Delay (2500);
					mycard4 = dealDeck.dealCard ();
					aceTest (mycard1, 0);
					aceTest (mycard2, 1);
					aceTest (mycard3, 2);
					aceTest (mycard4, 3);
					myCard4Label.Text = mycard4.getRank () + " of " + mycard4.getSuit ();
					myImage4.Image = UIImage.FromBundle (mycard4.getCardString ());

					// could refactor into its own function
					if(checkBust())
					{
						var alert = UIAlertController.Create("Whoa Whoa Whoa.", "You busted! \n" +
							"On a " + mycard4.getRank() + " of " + mycard4.getSuit()
							+ "\n Better hope the dealer busts.\n" +
								"He's dealing now. Hurry!", UIAlertControllerStyle.Alert);

						// add buttons
						alert.AddAction(UIAlertAction.Create("Okay :(", UIAlertActionStyle.Default, null));

						// actually show the thing
						PresentViewController(alert, true, null);
						hitButton.Hidden = true;
						doneButton.Hidden = true;
						await Task.Delay (2000);
						hitDealer ();
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

			try
			{
				mysum += mycard1.getNumericalRank ();
				mysum += mycard2.getNumericalRank ();
				mysum += mycard3.getNumericalRank ();
				mysum += mycard4.getNumericalRank ();
			}
			catch(Exception ex)
			{
				Console.Out.WriteLine ("updateCount error. One or more of your cards is null. Count: " + mysum);
				Console.Out.WriteLine ("Error: " + ex.ToString ());
			}
				
			try
			{
				housesum += housecard1.getNumericalRank ();
				housesum += housecard2.getNumericalRank ();
				housesum += housecard3.getNumericalRank ();
				housesum += housecard4.getNumericalRank ();
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
			cardstring += "\nYour cards: \n\n";
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
			cardstring += "\nHouse cards: \n\n";
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
			if (housesum > mysum && !checkHouseBust() && !checkBust()) 
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
			else if (housesum < mysum && !checkBust () && !checkHouseBust()) 
			{
				Console.Out.WriteLine ("You win!");
				resultLabel.Text = "You win!";

				var alert = UIAlertController.Create("You Win!", "Aww yeah!" + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Alright!", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);

			} else if (housesum == mysum && !checkBust() && !checkHouseBust()) 
			{
				Console.Out.WriteLine ("Push!");
				resultLabel.Text = "It was a push!";

				var alert = UIAlertController.Create("It was a push!", "Bummer, dude." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			else if(checkBust() && checkHouseBust())
			{
				Console.Out.WriteLine ("Push!");
				resultLabel.Text = "It was a push!";

				var alert = UIAlertController.Create("It was a push!", "Bummer, dude." + "\n" + printCards(), UIAlertControllerStyle.Alert);

				// add buttons
				alert.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));

				// actually show the thing
				PresentViewController(alert, true, null);
			}
			else if(housesum < mysum && checkBust() && !checkHouseBust())
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
			else if(housesum > mysum && !checkBust() && checkHouseBust())
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
			// add all the cards back to the deck
			dealDeck = null;
			dealDeck = new Deck ();

			// make all the cards null. why aren't there 1's and 2's here?
			mycard3 = null;
			mycard4 = null;
			housecard3 = null;
			housecard4 = null;

			// hide the labels
			myCard3Label.Hidden = true;
			myCard4Label.Hidden = true;
			houseCard3Label.Hidden = true;
			houseCard4Label.Hidden = true;
			hitButton.Hidden = true;
			doneButton.Hidden = true;

			// hide the images
			myImage1.Image = UIImage.FromBundle (" ");
			myImage2.Image = UIImage.FromBundle (" ");
			myImage3.Image = UIImage.FromBundle (" ");
			myImage4.Image = UIImage.FromBundle (" ");
			houseImage1.Image = UIImage.FromBundle (" ");
			houseImage2.Image = UIImage.FromBundle (" ");
			houseImage3.Image = UIImage.FromBundle (" ");
			houseImage4.Image = UIImage.FromBundle (" ");

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
			myImage1.Image = UIImage.FromBundle (mycard1.getCardString ());

			myImage2.Image = UIImage.FromBundle ("back.png");
			houseImage1.Image = UIImage.FromBundle ("back.png");
			houseImage2.Image = UIImage.FromBundle ("back.png");

			await Task.Delay (2500);
			mycard2 = dealDeck.dealCard ();
			myCard2Label.Text = mycard2.getRank () + " of " + mycard2.getSuit ();
			myImage2.Image = UIImage.FromBundle (mycard2.getCardString ());
			await Task.Delay (2500);
			aceTest (mycard1, 0);
			aceTest (mycard2, 1);

			// deal the dealer in
			housecard1 = dealDeck.dealCard ();
			houseCard1Label.Text = housecard1.getRank () + " of " + housecard1.getSuit ();
			houseImage1.Image = UIImage.FromBundle (housecard1.getCardString ());
			await Task.Delay (2500);
			housecard2 = dealDeck.dealCard ();
			houseCard2Label.Text = housecard2.getRank () + " of " + housecard2.getSuit ();
			houseImage2.Image = UIImage.FromBundle (housecard2.getCardString ());
			aceTest (housecard1, 4);
			aceTest (housecard2, 5);

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

