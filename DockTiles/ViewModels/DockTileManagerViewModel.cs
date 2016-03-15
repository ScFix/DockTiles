using DockTiles.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DockTiles.Models;

namespace DockTiles.ViewModels
{
	public class DockTileManagerViewModel : ViewModelBase, IDockTileManager
	{
		#region Properties
		private IDockTileParent _TreeRoot;
		public IDockTile TreeRoot
		{
			get { return _TreeRoot; }
		}
		#endregion //Properties

		#region Members
		protected Dictionary<Object, IDockTile> ObjectToDocktileMap = new Dictionary<Object, IDockTile>();
		#endregion //Members

		#region Constructor
		/// <summary>
		/// Creates the manager that will be used to be displayed in a ContentPresenter
		/// </summary>
		/// <param name="rootView"> The root ViewModel to be displayed on Items</param>
		public DockTileManagerViewModel(Object rootView)
		{
			IDockTile dockTile = new LeafViewModel() { Item = rootView };
			//add the base item to the map
			ObjectToDocktileMap.Add(rootView, dockTile);

			_TreeRoot = new RootDockTile() { Item = dockTile };
			dockTile.Parent = _TreeRoot;
		}
		#endregion //Constructor

		#region Methods
		/// <summary>
		/// Adds a new Item to the DockTile Configuration
		/// </summary>
		/// <param name="destinationItem">This is the base item that the new item will dock to</param>
		/// <param name="item">This is the item that you wish to display, this item cannot already be apart of the DockTiles</param>
		/// <param name="dockDirection">The basic cardinal direction of that the item will dock to the base item</param>
		public void AddTile(Object destinationItem, Object item, DockTileDirection dockDirection)
		{
			// NOTE(MATTHEW): if we have the item in the map and the person is not docking an item to itself. 
			if (ObjectToDocktileMap.ContainsKey(item) || ObjectToDocktileMap.ContainsValue(item as IDockTile))
			{
				// TODO(Matthew):  decide what the default behavior for this stuff truly is. 
				throw new Exception();
			}
			if (destinationItem != item && ObjectToDocktileMap.ContainsKey(destinationItem))
			{
				IDockTile baseDockTile = null;
				IDockTile dockedItem = new LeafViewModel() { Item = item };
				ObjectToDocktileMap.TryGetValue(destinationItem, out baseDockTile);
				ObjectToDocktileMap.Add(item, dockedItem);
				if (baseDockTile.Parent != null)
				{
					baseDockTile.Dock(dockedItem, dockDirection);
				}

			}

		}

		/// <summary>
		/// Removes Object from DockTiles
		/// </summary>
		/// <param name="tile">The object that will be removed if it is in the Tiles</param>
		/// <returns></returns>
		public bool RemoveTile(Object tile)
		{
			IDockTile baseDockTile = null;
			ObjectToDocktileMap.TryGetValue(tile, out baseDockTile);
			if (baseDockTile != null)
			{
				(baseDockTile.Parent as ISplitDockTile).RemoveDockTile(baseDockTile);
				ObjectToDocktileMap.Remove(tile);
				return true;
			}
			return false;
		}

		/// <summary>
		/// This will move an item to the new lovation.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="destinationItem"></param>
		/// <param name="dockDirection"></param>
		public void MoveTile(Object destinationItem, Object item, DockTileDirection dockDirection)
		{
			if (ObjectToDocktileMap.ContainsKey(item))
			{
				RemoveTile(item);
				AddTile(destinationItem, item, dockDirection);
			}
		}
		#endregion //Methods

	}
}
