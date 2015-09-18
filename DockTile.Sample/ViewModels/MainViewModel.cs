using DockTiles.Models;
using DockTiles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTile.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private DockTileManagerViewModel _View;
        public DockTileManagerViewModel View
        {
            get
            {
                return _View;
            }
            set
            {
                if (_View != value)
                {
                    _View = value;
                    OnPropertyChanged("View");
                }
            }
        }

        public MainViewModel()
        {
            var item1 = new SampleViewModel() { Color = "Rose", Name = "1" };
            var item2 = new SampleViewModel() { Color = "Red", Name = "2" };
            var item3 = new SampleViewModel() { Color = "Blue", Name = "3" };
            var item4 = new SampleViewModel() { Color = "LightBlue", Name = "4" };
            View = new DockTileManagerViewModel(item1);
            View.AddTile(item1, item2, DockTileDirection.Top);
            View.AddTile(item1, item3, DockTileDirection.Right);
            View.AddTile(item1, item4, DockTileDirection.Right);


        }
    }
}
