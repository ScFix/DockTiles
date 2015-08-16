using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.ViewModels
{
    public class LeafViewModel : ViewModelBase
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
