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
                System.Windows.Forms.MessageBox.Show(ex.Message + "Ok.");
            }
            return sqliteConn;
        }

        
        public static void CreateTable()
        {
            SQLiteCommand sqliteCommand;
            string createSQL = @"
                CREATE TABLE 'Persona' (
	            'idCedula' INTEGER PRIMARY KEY AUTOINCREMENT,
	            'Nombre' TEXT,
	            'Nacionalidad' TEXT,
	            'Fecha_nacimineto'  TEXT,
	            'Sexo'  TEXT,
	            'Cedula'   INTEGER,
	            'Direccion' TEXT,
	            'Telefono'  INTEGER,
	            'Imagen'    BLOB
                 ); 

                 CREATE TABLE 'Servicio' (
                'idServicio'    INTEGER PRIMARY KEY AUTOINCREMENT,
	            'Nombre'   TEXT NOT NULL
                 );

                INSERT INTO Servicio(Nombre) VALUES 
                ('Acta de nacimineto');

                CREATE TABLE 'RegistroSolicitud' (
                'idRegistro'   INTEGER PRIMARY KEY AUTOINCREMENT,
	            'Solicitud' TEXT,
	            'idPersona' INTEGER NOT NULL,
	            'Fecha_Solicitud'   TEXT,
	            'Estado'    TEXT,
                'Descripcion' TEXT);
            ";
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
