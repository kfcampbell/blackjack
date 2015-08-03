using System;
using System.Threading.Tasks;
using UIKit;

namespace BlackJack
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

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

			/*Deck dealDeck = new Deck ();

			// alright, deal me in.
			Card mycard1 = dealDeck.dealCard ();

			Card mycard2 = dealDeck.dealCard ();

			// deal the dealer in
			Card housecard1 = dealDeck.dealCard ();
			Card housecard2 = dealDeck.dealCard ();

			Console.Out.WriteLine ("mycard1: " + mycard1.getRank () + " " + mycard1.getSuit ());
			Console.Out.WriteLine ("mycard2: " + mycard2.getRank () + " " + mycard2.getSuit ());
			Console.Out.WriteLine ("my cards summed: " + mycard1.getNumericalRank () + mycard2.getNumericalRank ());

			Console.Out.WriteLine ("housecard1: " + housecard1.getRank () + " " + housecard1.getSuit ());
			Console.Out.WriteLine ("housecard2: " + housecard2.getRank () + " " + housecard2.getSuit ());
			Console.Out.WriteLine ("house cards summed: " + housecard1.getNumericalRank () + housecard2.getNumericalRank ());*/

			playButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				threadSleep ();
			};

		}

		public async void threadSleep()
		{
			Deck dealDeck = new Deck ();

			// alright, deal me in.
			Card mycard1 = dealDeck.dealCard ();
			myCard1Label.Text = mycard1.getRank () + " of " + mycard1.getSuit ();
			myCard2Label.Text = "Dealing...";
			houseCard1Label.Text = "Dealing...";
			houseCard2Label.Text = "Dealing...";
			await Task.Delay (2500);
			Card mycard2 = dealDeck.dealCard ();
			myCard2Label.Text = mycard2.getRank () + " of " + mycard2.getSuit ();
			await Task.Delay (2500);

			// deal the dealer in
			Card housecard1 = dealDeck.dealCard ();
			houseCard1Label.Text = housecard1.getRank () + " of " + housecard1.getSuit ();
			await Task.Delay (2500);
			Card housecard2 = dealDeck.dealCard ();
			houseCard2Label.Text = housecard2.getRank () + " of " + housecard2.getSuit ();

			Console.Out.WriteLine ("mycard1: " + mycard1.getRank () + " " + mycard1.getSuit ());
			Console.Out.WriteLine ("mycard2: " + mycard2.getRank () + " " + mycard2.getSuit ());

			int mycardsum = mycard1.getNumericalRank () + mycard2.getNumericalRank ();
			Console.Out.WriteLine ("my cards summed: " + mycardsum);

			Console.Out.WriteLine ("housecard1: " + housecard1.getRank () + " " + housecard1.getSuit ());
			Console.Out.WriteLine ("housecard2: " + housecard2.getRank () + " " + housecard2.getSuit ());
			int housecardsum = housecard1.getNumericalRank () + housecard2.getNumericalRank ();
			Console.Out.WriteLine ("house cards summed: " + housecardsum);

			if(housecardsum > mycardsum)
			{
				Console.Out.WriteLine ("House wins!");
				resultLabel.Text = "House wins!";
			}
			else if(housecardsum < mycardsum)
			{
				Console.Out.WriteLine ("You win!");
				resultLabel.Text = "You win!";
			}
			else if(housecardsum == mycardsum)
			{
				Console.Out.WriteLine ("Push!");
				resultLabel.Text = "It was a push! If my programmer was more\r talented, we wouldn't have this issue.";
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

