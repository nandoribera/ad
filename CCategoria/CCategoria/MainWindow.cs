using Gtk;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using CCategoria;

using System.Reflection;

public partial class MainWindow : Gtk.Window
{
	private IDbConnection dbConnection;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        
 //     //CREACION DE OBJETO
		//object obj = null;
		//object result = obj + "";

		//Console.WriteLine(result);
		//Console.WriteLine("ctor fin");

        //CONEXION BBDD
		dbConnection = new MySqlConnection(
                "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
            );
		dbConnection.Open();
        
		//insert();
		update(new Categoria(3, "categoria 3 " + DateTime.Now));
		//delete();

		//AGREGAR COLUMNAS Y DATOS AL treeView
		CellRendererText cellRendererText = new CellRendererText();
		treeView.AppendColumn(
			"Id",
			cellRendererText,
			delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter){
				//Categoria categoria = (Categoria)tree_model.GetValue(iter, 0);
				//cellRendererText.Text = categoria.Id.ToString();
			    object model = tree_model.GetValue(iter, 0);
				object value = model.GetType().GetProperty("Id").GetValue(model);
			    cellRendererText.Text = value.ToString();
		    }
		);

		treeView.AppendColumn(
            "Nombre",
            cellRendererText,
            delegate (TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
			    //Categoria categoria = (Categoria)tree_model.GetValue(iter, 0);
			    //cellRendererText.Text = categoria.Nombre;
			object model = tree_model.GetValue(iter, 0);
                object value = model.GetType().GetProperty("Nombre").GetValue(model);
                cellRendererText.Text = value.ToString();

            }
        );

		string[] properties = new string[] { "id", "Nombre" };

		foreach (string property in properties){
			string propertyName = property;
		}

        //MODELO Y TIPO DE DATOS DEL treeView
		ListStore listStore = new ListStore(typeof(Categoria));
		treeView.Model = listStore;
        
        //INSERTAR VALORES A listStore
		//listStore.AppendValues("1","cat1");
		//listStore.AppendValues("2","cat2");

        //COMANDO PARA INSERTAR DATOS DE BBDD Al treeView
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "select id, nombre from categoria order by id";
		IDataReader dataReader = dbCommand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(new Categoria((ulong)dataReader["id"], (string)dataReader["nombre"]));
		dataReader.Close();

		dbConnection.Close();

    }

	private void insert()
    {
		//COMANDO PARA INSERTAR DATOS EN BBDD


		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "insert into categoria (nombre) values('Categoria 4')";
		dbCommand.ExecuteNonQuery();
    }

	private void update(Categoria categoria)
    {
        //COMANDO PARA ACTUALIZAR DATOS EN BBDD


        IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "update categoria set nombre=@nombre where id=@id";

        //INTRODUCIR PARAMETROS EN CONSULTAS
		IDbDataParameter dbDataParameterNombre = dbCommand.CreateParameter();
		dbDataParameterNombre.ParameterName = "nombre";
		dbDataParameterNombre.Value = categoria.Nombre;
		dbCommand.Parameters.Add(dbDataParameterNombre);
        
        IDbDataParameter dbDataParameterId = dbCommand.CreateParameter();
		dbDataParameterId.ParameterName = "id";
		dbDataParameterId.Value = categoria.Id;
		dbCommand.Parameters.Add(dbDataParameterId);
        
        dbCommand.ExecuteNonQuery();
    }

	private void delete()
    {
        //COMANDO PARA BORRAR DATOS EN BBDD


        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "delete from categoria where id=4";
        dbCommand.ExecuteNonQuery();
    }
    

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
