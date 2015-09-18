using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.Interfaces
{
    public interface IDockTile
    {
        IDockTileParent Parent { get; set; }

        void Dock(IDockTile item, DockTileDirection dockDirection);
    }
}
