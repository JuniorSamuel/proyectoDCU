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
            sqliteConn = new SQLiteConnection("Data Source = DatabaseFaceId.db;");
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

        
        public static void CreateTable()
        {
            SQLiteCommand sqliteCommand;
            string createSQL = @"
                CREATE TABLE 'Persona' (
                'idCedula'  INTEGER,
	            'nombre'    TEXT NOT NULL,
	            'Nacionalidad'  TEXT NOT NULL,
	            'fecha_nacimineto'  TEXT NOT NULL,
	            'sexo'  TEXT NOT NULL,
	            'cedula'   INTEGER NOT NULL UNIQUE,
                'Direccion' TEXT NOT NULL,
	            'Telefono'  INTEGER,
	            'Imagen'    BLOB,
	            PRIMARY KEY('idCedula','idCedula' AUTOINCREMENT)
            ); ";
            sqliteCommand = ConnectorSQLite.CreateConnection().CreateCommand();
            sqliteCommand.CommandText = createSQL;
            try
            {
                sqliteCommand.ExecuteNonQuery();

            }
            catch
            {

            }
        }

    }
}
