using System;

namespace XtremeModpackLazyness
{
	public partial class Main_Window : Gtk.Window
	{
		public Main_Window () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

