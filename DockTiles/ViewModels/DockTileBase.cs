using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
	public class DockTileBase : ViewModelBase, IDockTile
	{
		private IDockTileParent _Parent;
		public IDockTileParent Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				if (_Parent != value)
				{
					_Parent = value;
					OnPropertyChanged("Parent");
				}
			}
		}

		public virtual void Dock(IDockTile dockie, DockTileDirection dockDirection)
		{
			ISplitDockTile node = null;
			switch (dockDirection)
			{
				case DockTileDirection.Left:
				case DockTileDirection.Right:
					node = new HorizontalSplitViewModel();
					break;
				case DockTileDirection.Top:
				case DockTileDirection.Bottom:
					node = new VerticalSplitViewModel();
					break;
			}
			switch (dockDirection)
			{
				case DockTileDirection.Left:
				case DockTileDirection.Top:
					node.LeftNode = dockie;
					node.RightNode = this;
					break;
				case DockTileDirection.Right:
				case DockTileDirection.Bottom:
					node.LeftNode = this;
					node.RightNode = dockie;
					break;
			}

			Parent.ReplaceNode(this, node);
			//Place both parents DOH!
			this.Parent = node;
			dockie.Parent = node;
		}

	}
}
