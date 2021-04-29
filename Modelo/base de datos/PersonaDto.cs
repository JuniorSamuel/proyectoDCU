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
            try
            {
                System.Windows.Forms.MessageBox.Show(perosna.ToString());
                SQLiteConnection conn = ConnectorSQLite.CreateConnection();
                SQLiteCommand sqliteCommand;
                sqliteCommand = conn.CreateCommand();
                sqliteCommand.CommandText = @"INSERT INTO Persona( 
                    Cedula, Nombre, Nacionalidad, Fecha_nacimineto, 
                    Sexo, Direccion, Telefono) VALUES (
                    " + perosna.cedula + 
                    ", '" + perosna.nombre+"'" +
                    ", '" + perosna.nacionalidad+"'" +
                    ", '" + perosna.fecha_nacimiento + "'"+
                    ", '" + perosna.sexo + "'"+
                    ", '" + perosna.direccion +"'" +
                    ",  " + perosna.telefono +");";
                int var = sqliteCommand.ExecuteNonQuery();
                conn.Close();
            }catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error insert persona:" + ex.Message);
            }
        }

        public Persona getPerosna(int cedula)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Persona where Cedula = " + cedula + "; ";
            reader = command.ExecuteReader();
            if (reader.Read())
                perosna = new Persona{
                    idPersona = reader.GetInt32(0), 
                    nombre = reader.GetString(1), 
                    nacionalidad = reader.GetString(2), 
                    fecha_nacimiento = reader.GetString(3), 
                    sexo = reader.GetString(4), 
                    cedula = reader.GetInt32(5),
                    direccion = reader.GetString(6),
                    telefono = reader.GetInt32(7)
                };            
            else
            {
                perosna = null;
            }
            return perosna;
            conn.Close();
        }
    }
}
