using DockTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.Interfaces
{
    public interface IDockTileManager
    {
        IDockTile TreeRoot { get; }
        bool RemoveTile(Object tile);
        void AddTile(Object item, Object targetItem, DockTileDirection dockDirection);

        //Implement tree manipiulation. 
    }
}
