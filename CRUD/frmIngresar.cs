using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class frmIngresar : Form
    {
        public frmIngresar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TIC.DatosPersona persona = new TIC.DatosPersona();
            persona.Cedula = this.txtCedula.Text;
            persona.Apellidos = this.txtApellidos.Text;
            persona.Nombres = this.txtNombres.Text;
            persona.FechaNacimiento = this.dtFechaNacimiento.Value;
            persona.Correo = this.txtCorreo.Text;
            persona.Estatura = Int32.Parse(this.txtEstatura.Text);
            persona.Peso = Decimal.Parse(this.txtPeso.Text);
            string genero = "F";
            if (this.cmbSexo.Text.ToString().Equals("Masculino"))
            {
                genero = "M";
            }
            persona.Sexo = genero;

            int x = TIC.DatosPersonasDAO.crear(persona);
            if (x > 0)
                MessageBox.Show("Registro agregado.....");
            else
                MessageBox.Show("No se pudo agregar el registro...");
        }

    }
}
