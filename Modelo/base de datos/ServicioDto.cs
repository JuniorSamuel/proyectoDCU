using FaceId.Modelo.Entidades;
using Modelo.Dao;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.base_de_datos
{
    class ServicioDto
    {
        public List<Servicio> getServicio()
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            List<Servicio> servicios = new List<Servicio>();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Servicio;";
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                servicios.Add(new Servicio
                {
                    idServicio = reader.GetInt32(0),
                    nombre = reader.GetString(1)
                });
            }else
            {
                servicios = null;
            }
                       
            return servicios;
            conn.Close();
        }
    }
}
