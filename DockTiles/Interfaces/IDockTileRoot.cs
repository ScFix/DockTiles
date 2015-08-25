using DockTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.Interfaces
{
    public interface IDockTileRoot
    {
        IDockTile TreeRoot { get; set; }
        bool RemoveTile(Object tile);
        void AddTile(Object item, Object targetItem, DockTileDirection dockDirection);
        //Implement tree manipiulation. 
    }
}
