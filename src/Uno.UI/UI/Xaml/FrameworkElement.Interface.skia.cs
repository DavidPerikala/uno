﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using System.Runtime.CompilerServices;
using System.Text;
using Uno.UI.Xaml;

namespace Windows.UI.Xaml
{

	public partial class FrameworkElement : UIElement, IFrameworkElement
	{
		public T FindFirstParent<T>() where T : class => FindFirstParent<T>(includeCurrent: false);

		public T FindFirstParent<T>(bool includeCurrent) where T : class
		{
			var view = includeCurrent ? (DependencyObject)this : this.Parent;
			while (view != null)
			{
				var typed = view as T;
				if (typed != null)
				{
					return typed;
				}
				view = view.GetParent() as DependencyObject;
			}
			return null;
		}

		#region Transitions Dependency Property

		[GeneratedDependencyProperty(DefaultValue = null, ChangedCallback = true)]
		public static DependencyProperty TransitionsProperty { get; } = CreateTransitionsProperty();

		public TransitionCollection Transitions
		{
			get => GetTransitionsValue();
			set => SetTransitionsValue(value);
		}

		private void OnTransitionsChanged(DependencyPropertyChangedEventArgs args)
		{

		}
		#endregion

		public object FindName(string name)
			=> IFrameworkElementHelper.FindName(this, GetChildren(), name);


		public void Dispose()
		{
		}

		public Size AdjustArrange(Size finalSize)
		{
			return finalSize;
		}

		public int? RenderPhase
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		private static readonly Uri DefaultBaseUri = new Uri("ms-appx://local");
		public global::System.Uri BaseUri
		{
			get;
			internal set;
		} = DefaultBaseUri;

		public void ApplyBindingPhase(int phase) => throw new NotImplementedException();

		#region Background DependencyProperty

		public Brush Background
		{
			get => (Brush)GetValue(BackgroundProperty);
			set => SetValue(BackgroundProperty, value);
		}

		// Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
		public static DependencyProperty BackgroundProperty { get; } =
			DependencyProperty.Register("Background", typeof(Brush), typeof(FrameworkElement), new FrameworkPropertyMetadata(null, (s, e) => ((FrameworkElement)s)?.OnBackgroundChanged(e)));


		protected virtual void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
		{

		}

		#endregion
	}
}
