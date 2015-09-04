using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.ViewModels;

namespace DockTiles.Interfaces
{
    public interface ISplitDockTile : IDockTile, IDockTileParent
    {
        IDockTile LeftNode { get; set; }
        IDockTile RightNode { get; set; }
        void RemoveDockTile(IDockTile dockTile);
    }
}
