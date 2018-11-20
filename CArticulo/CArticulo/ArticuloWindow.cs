using System;

using Serpis.Ad;
using Serpis.Ad.Ventas;

namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
    {
		public ArticuloWindow(Articulo articulo) : base(Gtk.WindowType.Toplevel) {
            this.Build();
			EntityDao<Articulo> articuloDao = new EntityDao<Articulo>();
			entryNombre.Text = articulo.Nombre;
            
			buttonSave.Clicked += delegate {
				articulo.Nombre = entryNombre.Text;
				articuloDao.Save(articulo);


                
			};
        }
    }
}
