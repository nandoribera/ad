using System;
using System.Data;
using Serpis.Ad;
namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
        public CategoriaWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();



			buttonSave.Clicked += delegate
			{
				//CONEXIÓN BBDD A PARTIR DE OBJETO
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();

                //CONSULTA
				dbCommand.CommandText = "insert into categoria (nombre) values(@nombre)";

                //AÑADIR DATOS POR METODO DBCOMMANDHELPER
				dBCommandHelper.AddParemeter(dbCommand, "nombre", entryNombre.Text);

				int filas = dbCommand.ExecuteNonQuery();
			};
        }

	}
}
