using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Interfaces;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
	public class RootDockTile : DockTileBase, IDockTileParent
	{

		private IDockTile _Item;
		public IDockTile Item
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

		public void ReplaceNode(IDockTile CurrentNode, IDockTile nd)
		{
			if (Item == CurrentNode)
			{
				Item.Parent = null;
				Item = nd;
				Item.Parent = this;
			}
		}
	}
}
