using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockTile.Sample.ViewModels
{
	public class SampleViewModel : IDragSource
	{
		public string Color { get; set; }
		public string Name { get; set; }

		public bool CanStartDrag(IDragInfo dragInfo)
		{
			return true;
		}

		public void DragCancelled()
		{
			//Do Nothing
		}

		public void DragOver(IDropInfo dropInfo)
		{
			//Do Nothing	
		}

		public void StartDrag(IDragInfo dragInfo)
		{
			//Console.WriteLine("Starting Drag");
			dragInfo.Data = this;
			dragInfo.Effects = System.Windows.DragDropEffects.Move;
		}

		public void Drop(IDropInfo dropInfo)
		{
			Console.WriteLine("Drop");
		}

		public void Dropped(IDropInfo dropInfo)
		{
			Console.WriteLine("Dropped");
		}


	}
}
