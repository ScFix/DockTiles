using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.ViewModels
{
    public class LeafViewModel : ViewModelBase, IDockTile
    {
        public object _Item;
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

    }
}
