using Emgu.CV;
using Emgu.CV.Structure;
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
    class ImagenDto
    {
        Imagen imagen;

        public ImagenDto(Imagen imagen)
        {
            this.imagen = imagen;
        }

        public void setImagen(Imagen imagen)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = @"INSERT INTO Persona( idImagen, idCedula, imagen) VALUES (" +
                "'" + imagen.idImagen+ "', " +
                "" + imagen.idCedula + ", " +
                "" + imagen.imagen + ");";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public Imagen getPerosna(int idImagen)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Imagen where idCedula = " + idImagen + " ";
            //reader = command.ExecuteReader();
            //if (reader.Read())
            //    imagen = new Imagen( reader.GetInt32(0), reader.GetInt32(1), (Image)reader.GetBlob(2, true));
            //else
                imagen = null;

            return imagen;
            conn.Close();
        }
    }
}   
