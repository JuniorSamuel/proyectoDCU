using FaceId.Modelo.base_de_datos;
using FaceId.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion
{
    public partial class FrmRegistroBTN : Form
    {
        public FrmRegistroBTN()
        {
            InitializeComponent();
            MessageBox.Show("Hola");
        }

        private void btnGuardarREBTN_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            PersonaDto personaDto = new PersonaDto();
            persona.cedula = Int32.Parse(txtCedula.Text);
            persona.nombre = txtNombre.Text;
            if (rdbMasculino.Checked)
            {
                persona.sexo = "M";
            }
            if (rdbFemenino.Checked)
            {
                persona.sexo = "F";
            }
            persona.telefono = Int32.Parse(txtTelefono.Text);
            persona.direccion = txtDireccion.Text;
            persona.nacionalidad = txtNacionalidad.Text;
            persona.apellido = txtApellido.Text;
            personaDto.setPersona(persona);
        }
    }
}
