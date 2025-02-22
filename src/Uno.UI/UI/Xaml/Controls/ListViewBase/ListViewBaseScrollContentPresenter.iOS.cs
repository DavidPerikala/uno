﻿using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using UIKit;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.Foundation;

#if NET6_0_OR_GREATER
using ObjCRuntime;
#endif

namespace Windows.UI.Xaml.Controls
{
	public sealed partial class ListViewBaseScrollContentPresenter : IScrollContentPresenter
	{
		public CGPoint UpperScrollLimit => NativePanel?.UpperScrollLimit ?? CGPoint.Empty;

		public UIEdgeInsets ContentInset
		{
			get => NativePanel?.ContentInset ?? default(UIEdgeInsets);
			set => NativePanel.ContentInset = value;
		}

		Size? IScrollContentPresenter.CustomContentExtent => NativePanel?.ContentSize;

		CGPoint IUIScrollView.ContentOffset => NativePanel?.ContentOffset ?? default(CGPoint);

		nfloat IUIScrollView.ZoomScale => NativePanel?.ZoomScale ?? default(nfloat);

		void IUIScrollView.ApplyZoomScale(nfloat scale, bool animated)
		{
			if (NativePanel == null)
			{
				return;
			}

			if (animated)
			{
				NativePanel.SetZoomScale(scale, animated);
			}
			else
			{
				NativePanel.ZoomScale = scale;
			}
		}

		void IUIScrollView.ApplyContentOffset(CGPoint contentOffset, bool animated)
		{
			if (NativePanel == null)
			{
				return;
			}

			if (animated)
			{
				NativePanel.SetContentOffset(contentOffset, animated);
			}
			else
			{
				NativePanel.ContentOffset = contentOffset;
			}
		}

		public void SetContentOffset(CGPoint contentOffset, bool animated)
		{
			NativePanel?.SetContentOffset(contentOffset, animated);
		}

		public void SetZoomScale(nfloat scale, bool animated)
		{
			NativePanel?.SetZoomScale(scale, animated);
		}

		bool INativeScrollContentPresenter.Set(
			double? horizontalOffset,
			double? verticalOffset,
			float? zoomFactor,
			bool disableAnimation,
			bool isIntermediate)
			=> throw new NotImplementedException();
	}
}
