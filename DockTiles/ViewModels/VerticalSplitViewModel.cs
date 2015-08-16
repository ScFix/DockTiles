using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.ViewModels
{
    public class VerticalSplitViewModel : ViewModelBase, ISplitDockTile
    {
        public IDockTile LeftNode { get; set; }
        public IDockTile RightNode { get; set; }
    }
}
