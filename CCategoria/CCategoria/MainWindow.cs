using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        
 //     //CREACION DE OBJETO
		//object obj = null;
		//object result = obj + "";

		//Console.WriteLine(result);
		//Console.WriteLine("ctor fin");

        //CONEXION BBDD
		IDbConnection dbConnection = new MySqlConnection(
                "server=localhost;database=dbprueba;user=root;password=sistemas;ssl-mode=none"
            );
		dbConnection.Open();
            
        //AGREGAR COLUMNAS AL treeView
		treeView.AppendColumn("ID", new CellRendererText(), "text", 0);
		treeView.AppendColumn("Nombre", new CellRendererText(), "text", 1);

        //MODELO Y TIPO DE DATOS DEL treeView
		ListStore listStore = new ListStore(typeof(ulong), typeof(String));
		treeView.Model = listStore;

        //INSERTAR VALORES A listStore
		//listStore.AppendValues("1","cat1");
		//listStore.AppendValues("2","cat2");

        //COMANDO PARA INSERTAR DATOS DE BBDD Al treeView
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText = "select id, nombre from categoria order by id";
		IDataReader dataReader = dbCommand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(dataReader["id"],dataReader["nombre"]);
		dataReader.Close();

		dbConnection.Close();
            
        

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
