using DockTiles.Models;
using DockTiles.ViewModels;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DockTile.Sample.ViewModels
{

	public class MainViewModel : ViewModelBase, IDropTarget
	{

		private DockTileManagerViewModel _View;
		public DockTileManagerViewModel View
		{
			get
			{
				return _View;
			}
			set
			{
				if (_View != value)
				{
					_View = value;
					OnPropertyChanged("View");
				}
			}
		}

		public MainViewModel()
		{
			var item1 = new SampleViewModel() { Color = "Pink", Name = "1" };
			var item2 = new SampleViewModel() { Color = "Red", Name = "2" };
			var item3 = new SampleViewModel() { Color = "Blue", Name = "3" };
			var item4 = new SampleViewModel() { Color = "LightBlue", Name = "4" };
			View = new DockTileManagerViewModel(item1);
			View.AddTile(item1, item2, DockTileDirection.Top);
			View.AddTile(item1, item3, DockTileDirection.Right);
			View.AddTile(item1, item4, DockTileDirection.Right);
		}

		public void DragOver(IDropInfo dropInfo)
		{
			if ((dropInfo.VisualTarget as FrameworkElement).DataContext != dropInfo.Data)
				dropInfo.Effects = System.Windows.DragDropEffects.Move;
		}

		public void Drop(IDropInfo dropInfo)
		{
			// TODO(Matthew) clean this up a bit
			double Height = dropInfo.VisualTarget.RenderSize.Height;
			double Width = dropInfo.VisualTarget.RenderSize.Width;
			Point center = new Point(Width / 2, Height / 2);
			double x = dropInfo.DropPosition.X;
			double y = dropInfo.DropPosition.Y;
			x = x - center.X;
			y = y - center.Y;

			Matrix v = new Matrix(x, y, 0, 0, 0, 0);
			v.Rotate(45);
			x = v.M11;
			y = v.M12;

			var data = dropInfo.Data;
			var target = (dropInfo.VisualTarget as FrameworkElement).DataContext;

			if (x > 0 && y < 0)
			{
				View.MoveTile(target, data, DockTileDirection.Top);
			}
			else if (x > 0 && y > 0)
			{
				View.MoveTile(target, data, DockTileDirection.Right);
			}
			else if (x <= 0 && y > 0)
			{
				View.MoveTile(target, data, DockTileDirection.Bottom);
			}
			else
			{
				View.MoveTile(target, data, DockTileDirection.Left);
			}


		}


	}
}
