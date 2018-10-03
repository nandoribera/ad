using Gtk;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using CCategoria;
using Serpis.Ad;

using System.Reflection;

public partial class MainWindow : Gtk.Window
{

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();

		new CategoriaWindow();

		//CONEXION BBDD
		App.Instance.DbConnection = new MySqlConnection(
				"server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
			);

		App.Instance.DbConnection.Open();

		//insert();
		//update(new Categoria(3, "categoria 3 " + DateTime.Now));
		//delete();

		TreeViewHelper.Fill(treeView, new string[] { "Id", "Nombre" }, CategoriaDao.Categorias);

		newAction.Activated += delegate
		{
			treeView.Selection.GetSelected(out TreeIter treeIter);



			Categoria categoria = (Categoria)treeView.Model.GetValue(treeIter, 0);
			Console.WriteLine("Categoria Id = " + categoria.Id);
		};

		treeView.Selection.Changed += delegate
		{
			refreshUI();

		};

		refreshUI();

	}

	public static object GetId(TreeView treeView)
	{
		return Get(treeView, "Id");
	}

	public static object Get(TreeView treeview, string propertyName)
	{
		if (treeview.Selection.GetSelected(out TreeIter treeIter))
			return null;
		object model = treeview.Model.GetValue(treeIter, 0);
		return model.GetType().GetProperty(propertyName).GetValue(model);
	}

	private void refreshUI()
	{
		bool treeViewIsSelected = treeView.Selection.CountSelectedRows() > 0;
		editAction.Sensitive = treeViewIsSelected;
		deleteAction.Sensitive = treeViewIsSelected;

	}

	private void insert()
	{
		//COMANDO PARA INSERTAR DATOS EN BBDD


		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "insert into categoria (nombre) values('Categoria 4')";
		dbCommand.ExecuteNonQuery();
	}

	private void update(Categoria categoria)
	{
		//COMANDO PARA ACTUALIZAR DATOS EN BBDD


		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";

		//INTRODUCIR PARAMETROS EN CONSULTAS
		dBCommandHelper.AddParemeter(dbCommand, "nombre", categoria.Nombre);


		dBCommandHelper.AddParemeter(dbCommand, "id", categoria.Id);


		dbCommand.ExecuteNonQuery();
	}

	private void delete()
	{
		//COMANDO PARA BORRAR DATOS EN BBDD


		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		dbCommand.CommandText = "delete from categoria where id=4";
		dbCommand.ExecuteNonQuery();
	}


	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close();
		Application.Quit();
		a.RetVal = true;
	}
}
