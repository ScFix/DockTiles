using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
    public class SplitDockTileViewModel : DockTileBase, ISplitDockTile
    {
        private IDockTile _LeftNode;
        public IDockTile LeftNode
        {
            get
            {
                return _LeftNode;
            }
            set
            {
                if (_LeftNode != value)
                {
                    _LeftNode = value;
                    OnPropertyChanged("LeftNode");
                }
            }
        }


        private IDockTile _RightNode;
        public IDockTile RightNode
        {
            get
            {
                return _RightNode;
            }
            set
            {
                if (_RightNode != value)
                {
                    _RightNode = value;
                    OnPropertyChanged("RightNode");
                }
            }
        }

        public void ReplaceNode(IDockTile leafViewModel, IDockTile nd)
        {
            if (LeftNode == leafViewModel)
            {
                LeftNode = nd;
            }
            else
            {
                if (RightNode == leafViewModel)
                {
                    RightNode = nd;
                }
            }
        }

        public void RemoveDockTile(IDockTile dockTile)
        {
            if (Parent != null)
            {
                if (dockTile == LeftNode)
                    Parent.ReplaceNode(this, RightNode);
                else
                    Parent.ReplaceNode(this, LeftNode);

            }
        }
    }
}
