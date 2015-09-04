﻿using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
    public class LeafViewModel : DockTileBase
    {
        private object _Item;
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
