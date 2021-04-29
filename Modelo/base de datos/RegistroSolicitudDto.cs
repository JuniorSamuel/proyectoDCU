using FaceId.Modelo.Entidades;
using Modelo.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.base_de_datos
{
    class RegistroSolicitudDto
    {
        public void setRegistro(RegistroSolicitud registro)
        {
            try
            {
                SQLiteConnection conn = ConnectorSQLite.CreateConnection();
                SQLiteCommand sqliteCommand;
                sqliteCommand = conn.CreateCommand();
                sqliteCommand.CommandText = @"INSERT INTO RegistroSolicitud( 
                    Solicitud, idPersona, Descripcion, Fecha_Solicitud) VALUES (
                    '" + registro.solicitd +"'"+
                    ", " + registro.idPersona + 
                    ", '" +registro.descripcion + "'" +
                    ",date());";
                int var = sqliteCommand.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(var + "");
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error insert persona:" + ex.Message);
            }
        }

        public DataSet dataSet()
        {
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from Persona", ConnectorSQLite.CreateConnection());
            da.Fill(ds);
            return ds;
        }

        public List<RegistroSolicitud> verRegistro()
        {
            ConnectorSQLite.CreateTable();
            List<RegistroSolicitud> registroSolicituds = new List<RegistroSolicitud>();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from RegistroSolicitud";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                registroSolicituds.Add(new RegistroSolicitud {
                    idRegistro =reader.GetInt32(0),
                    idPersona = reader.GetInt32(2),
                    solicitd = reader.GetString(1),
                    fecha = reader.GetString(3),
                    descripcion = reader.GetString(5)
                });
            }
            conn.Close();
            return registroSolicituds;
        }
    }
}
