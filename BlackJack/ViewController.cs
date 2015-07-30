using System;

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

			Card jack = new Card ("spades", "jack");
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

			thisDeck.dealCard ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

