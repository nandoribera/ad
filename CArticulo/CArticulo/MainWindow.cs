using System;
using Gtk;
using Serpis.Ad;
using Serpis.Ad.Ventas;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel) {
        Build();

		var list = new[] {
			new{Id= 1, Nombre = "Articulo1"},
			new{Id= 2, Nombre = "Articulo2"},
			new{Id= 1, Nombre = "Articulo1"}
		};

		EntityDao<Articulo> articuloDao = new EntityDao<Articulo>;

		TreeViewHelper.Fill(treeview2, new string[] { "id", "Nombre", "Precio" }, articuloDao<Articulo>);


    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a) {
        Application.Quit();
        a.RetVal = true;
    }
}
