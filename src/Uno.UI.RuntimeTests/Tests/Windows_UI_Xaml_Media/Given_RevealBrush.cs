﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using static Private.Infrastructure.TestServices;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Media
{
	[TestClass]
	[RunsOnUIThread]
	public class Given_RevealBrush
	{
		[TestMethod]
		public async Task When_RevealBrush_Assigned()
		{
			// Basic smoke test - RevealBrush is currently unimplemented, but it shouldn't break the layout

			var siblingBorder = new Border { Width = 43, Height = 22 };
			var gridWithRevealBackground = new Grid
			{
				Width = 57,
				Height = 34,
				Background = new RevealBackgroundBrush() { Color = Colors.Brown, FallbackColor = Colors.Brown },
			};
			var parentSP = new StackPanel
			{
				Children =
				{
					gridWithRevealBackground,
					siblingBorder
				}
			};

			WindowHelper.WindowContent = parentSP;
			await WindowHelper.WaitForLoaded(parentSP);

			await WindowHelper.WaitForEqual(57, () => gridWithRevealBackground.ActualWidth);
			Assert.AreEqual(34, gridWithRevealBackground.ActualHeight);

			// If `siblingBorder.X` is fractional (not always visible inside `Frame`) then the `Width` will be
			// Different screen size of high-res (scale > 1) devices can trigger this (fractional `X`) condition
			// along where the canvas start position is (relative to the unit test runner)
			// See https://github.com/unoplatform/uno/pull/9179 for more details
			var delta = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel == 2 ? 0.5d : 0.0d;

			Assert.AreEqual(43, siblingBorder.ActualWidth, delta);
			Assert.AreEqual(22, siblingBorder.ActualHeight);
		}
	}
}
