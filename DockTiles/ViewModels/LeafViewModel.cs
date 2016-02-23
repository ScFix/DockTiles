using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;
using System.Windows.Input;
using ScFix.Utility.Classes;

namespace DockTiles.ViewModels
{
	public class LeafViewModel : DockTileBase
	{
		private object _Item;
		public object Item
		{
			get
			{
				return _Item;
			}
			set
			{
				if (_Item != value)
				{
					_Item = value;
					OnPropertyChanged("Item");
				}

			}
		}

		public ICommand Remove
		{
			get
			{
				return new RelayCommand((object obj) =>
				{
					if (this.Parent is ISplitDockTile)
					{
						(this.Parent as ISplitDockTile).RemoveDockTile(this);
					}
				});
			}
		}
	}
}
