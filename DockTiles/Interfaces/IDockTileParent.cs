﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTiles.Interfaces
{
    public interface IDockTileParent
    {
        void ReplaceNode(IDockTile CurrentNode, IDockTile nd);
    }
}
