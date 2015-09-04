using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DockTiles.Interfaces;
using DockTiles.ViewModels;
using DockTiles.Models;

namespace DockTileTest
{
    [TestClass]
    public class DockTileMangerTest
    {
        [TestMethod]
        public void AddingItems()
        {
            string obj1 = "object 1";
            string obj2 = "object 2";
            string obj3 = "object 3";

            IDockTileManager manager = new DockTileManagerViewModel(obj1);
            manager.AddTile(obj1, obj2, DockTileDirection.Left);
            manager.AddTile(obj1, obj3, DockTileDirection.Right);
            Assert.AreEqual(true, manager.TreeRoot is RootDockTile);
            Assert.AreEqual(true, (manager.TreeRoot as RootDockTile).Item is ISplitDockTile);
        }
    }
}
