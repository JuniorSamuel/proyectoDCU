using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Modelo.Dao
{
    public class ConnectorSQLite
    {
        
        //SQLiteConnection sqliteConn;
        public static SQLiteConnection CreateConnection()
        {
            
            SQLiteConnection sqliteConn = null;
            //sqliteConn = new SQLiteConnection("Data Source = C:/Users/Samy/source/repos/FaceId/Modelo/base de datos/DatabaseFaceId.db;");
            try
            {

                sqliteConn.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return sqliteConn;
        }

        /*
        public static void CreateTable()
        {
            SQLiteCommand sqliteCommand;
            string createSQL = @"
            CREATE TABLE 'Categoria' (
                'IdCategoria'   INTEGER,
	            'Nombre'    TEXT,
	            'Estado'    INTEGER,
	             PRIMARY KEY('IdCategoria' AUTOINCREMENT)
            );
            CREATE TABLE 'Producto' ( 
                'IdProducto'    INTEGER,	
                'Nombre'    TEXT,	
                'Codigo'    INTEGER,	
                'Stock' INTEGER,	
                'Fecha_vencimiento' TEXT,
	            'Descripcion'   TEXT,
	            'Categoria' INTEGER,
	            'Estado'    INTEGER,
            PRIMARY KEY('IdProducto' AUTOINCREMENT),
            FOREIGN KEY('Categoria') REFERENCES Categoria(IdCategoria) 
            );
			
			INSERT INTO Categoria(Nombre, Estado) VALUES
                ('Categoria 1', 1), 
                ('Categoria 2', 1), 
                ('Categoria 3', 1), 
                ('Categoria 4', 1), 
                ('Categoria 5', 1) ;         
            INSERT INTO Producto( Nombre, Codigo, Stock, Fecha_vencimiento, Descripcion, Categoria, Estado) VALUES 
                ('Producto 1', 1234, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 1, 0),
                ('Producto 2', 1235, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 2, 0),
                ('Producto 3', 1236, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 1, 0),
                ('Producto 4', 1237, 0, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 4, 0),
                ('Producto 5', 1238, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 5, 0),
                ('Producto 6', 1240, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 4, 0),
                ('Producto 7', 1241, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 2, 0),
                ('Producto 8', 1242, 1, 'miércoles, 17 de marzo de 2021', 'Descripcion de producto', 3, 0);";
            sqliteCommand = ConnectorSQLite.CreateConnection().CreateCommand();
            sqliteCommand.CommandText = createSQL;
            try
            {
                sqliteCommand.ExecuteNonQuery();

            }
            catch
            {

            }
        }*/

    }
}
