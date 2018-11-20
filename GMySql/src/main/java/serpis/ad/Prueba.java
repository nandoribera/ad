package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Prueba {

	public static void main(String[] args) throws SQLException {
		//Crear conexión con DB
		Connection conn = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		//Connection conn = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
		
		//Crear nuevo statement
		Statement stmnt = conn.createStatement();
		
		//crear la consulta con Result set
		ResultSet rst = stmnt.executeQuery("select * from categoria");
		
		//mientras se lea un dato del ResultSet(rst) imprime la cadena formateada con los datos del objeto de la base de datos
		while (rst.next())
			System.out.printf("%s %s\n", rst.getObject(1), rst.getObject(2));
		stmnt.close(); //cierra el statement
		conn.close();
		

	}

}
