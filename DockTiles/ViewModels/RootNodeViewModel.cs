using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
    public class RootNodeViewModel : ViewModelBase, IDockTileRoot
    {
        private IDockTile _TreeRoot;
        public IDockTile TreeRoot
        {
            get { return _TreeRoot; }
            set
            {
                if (_TreeRoot != value)
                {
                    _TreeRoot = value;
                    OnPropertyChanged("TreeRoot");
                }
            }
        }

        protected Dictionary<object, IDockTile> ItemToDocktileMap;


        public void AddTile(Object item, Object targetItem, DockTileDirection dockDirection)
        {

        }

        public bool RemoveTile(Object tile)
        {
            return false;
        }
    }
}
