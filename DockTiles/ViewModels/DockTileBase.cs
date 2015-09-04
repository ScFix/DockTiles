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
        private ISplitDockTile _Parent;
        public ISplitDockTile Parent
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
            ISplitDockTile nd = null;
            switch (dockDirection)
            {
                case DockTileDirection.Left:
                case DockTileDirection.Right:
                    nd = new HorizontalSplitViewModel();
                    break;
                case DockTileDirection.Top:
                case DockTileDirection.Bottom:
                    nd = new VerticalSplitViewModel();
                    break;
            }
            switch (dockDirection)
            {
                case DockTileDirection.Left:
                case DockTileDirection.Top:
                    nd.LeftNode = dockie;
                    nd.RightNode = this;
                    break;
                case DockTileDirection.Right:
                case DockTileDirection.Bottom:
                    nd.LeftNode = this;
                    nd.RightNode = dockie;
                    break;
            }

            Parent.ReplaceNode(this, nd);
            this.Parent = nd;
        }

    }
}
