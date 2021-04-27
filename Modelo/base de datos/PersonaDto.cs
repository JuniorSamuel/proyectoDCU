using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FaceId.Modelo.Entidades;
using Modelo.Dao;

namespace FaceId.Modelo.base_de_datos
{
    class PersonaDto
    {
        Persona perosna;

        public PersonaDto() { }
        public PersonaDto(Persona perosna)
        {
            this.perosna = perosna;
            
        }

        public void setPersona(Persona perosna)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = @"INSERT INTO Persona( Cedula, nombre, fecha_nacimineto, sexo, Direccion, Nacionalidad, Telefono) VALUES (" +
                "" + perosna.cedula + ", " +
                "'"  + perosna.nombre + "', " +
                "'" + perosna.fecha_nacimiento + "', " +
                "'" + perosna.sexo + "'," +
                "'" + perosna.direccion+"'," +
                "'" + perosna.nacionalidad+"'," +
                "" + perosna.telefono+");";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
            System.Windows.Forms.MessageBox.Show("Final");
        }

        public Persona getPerosna(int cedula)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Persona where cedula = " + cedula + " ";
            reader = command.ExecuteReader();
            if (reader.Read())
                perosna = new Persona(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetInt32(7));
            else
            {
                perosna = null;
            }

            return perosna;
            conn.Close();
        }
    }
}
