// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BlackJack
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView fireworks { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel houseCard1Label { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel houseCard2Label { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel myCard1Label { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel myCard2Label { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton playButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel resultLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (fireworks != null) {
				fireworks.Dispose ();
				fireworks = null;
			}
			if (houseCard1Label != null) {
				houseCard1Label.Dispose ();
				houseCard1Label = null;
			}
			if (houseCard2Label != null) {
				houseCard2Label.Dispose ();
				houseCard2Label = null;
			}
			if (myCard1Label != null) {
				myCard1Label.Dispose ();
				myCard1Label = null;
			}
			if (myCard2Label != null) {
				myCard2Label.Dispose ();
				myCard2Label = null;
			}
			if (playButton != null) {
				playButton.Dispose ();
				playButton = null;
			}
			if (resultLabel != null) {
				resultLabel.Dispose ();
				resultLabel = null;
			}
		}
	}
}
