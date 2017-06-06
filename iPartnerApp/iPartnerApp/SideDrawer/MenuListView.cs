using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace iPartnerApp
{
	public class MenuListView : ListView
	{
		public MenuListView ()
		{
			List<MenuItem> data = new MenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.Transparent;
			//SeparatorVisibility = SeparatorVisibility.None;

			var cell = new DataTemplate (typeof(MenuCell));
			cell.SetBinding (MenuCell.TextProperty, "Title");
			cell.SetBinding (MenuCell.ImageSourceProperty, "IconSource");
			cell.SetValue(BackgroundColorProperty, Color.Transparent);
			ItemTemplate = cell;

		}
	}
}


