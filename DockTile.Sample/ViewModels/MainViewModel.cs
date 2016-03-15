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
			DockTileDirection direction = DetermineDirectionDropped(dropInfo.VisualTarget.RenderSize, dropInfo.DropPosition);

			var data = dropInfo.Data;
			var target = (dropInfo.VisualTarget as FrameworkElement).DataContext;
			View.MoveTile(target, data, direction);

		}

		private DockTileDirection DetermineDirectionDropped(Size element, Point dropPoint)
		{
			Point center = GetCenterOfSize(element);
			Point pointFromOrigin = GetOffsetFromCenter(center, dropPoint);
			Point rotatedPoint = RotatePointInRespectToCenter(pointFromOrigin);
			DockTileDirection direction = QuadrentToDirection(rotatedPoint);
			return direction;
		}

		private Point RotatePointInRespectToCenter(Point rotatePoint)
		{
			Point p = new Point();
			Matrix v = new Matrix(rotatePoint.X, rotatePoint.Y, 0, 0, 0, 0);
			v.Rotate(45);
			p.X = v.M11;
			p.Y = v.M12;

			return p;
		}

		private Point GetOffsetFromCenter(Point center, Point dropPoint)
		{
			Point p = new Point();
			p.X = dropPoint.X - center.X;
			p.Y = dropPoint.Y - center.Y;
			return p;
		}

		private DockTileDirection QuadrentToDirection(Point p)
		{
			if (p.X > 0 && p.Y < 0)
			{
				return DockTileDirection.Top;
			}
			else if (p.X > 0 && p.Y > 0)
			{
				return DockTileDirection.Right;
			}
			else if (p.X <= 0 && p.Y > 0)
			{
				return DockTileDirection.Bottom;
			}
			else
			{
				return DockTileDirection.Left;
			}
		}

		private Point GetCenterOfSize(Size s)
		{
			return new Point(s.Width / 2, s.Height / 2);
		}

	}
}
