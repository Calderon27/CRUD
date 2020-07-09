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
            persona.Cedula = "01929951";
            persona.Apellidos = "Calderon Lujano";
            persona.Nombres = "Carlos Daniel";
            persona.Sexo = "M";
            persona.FechaNacimiento = DateTime.Now.Date;
            persona.Correo = "cdcl200127@gmail.com";
            persona.Estatura = 165;
            persona.Peso = 78.45m;
            int x = TIC.DatosPersonasDAO.crear(persona);
            if (x > 0)
                MessageBox.Show("Registro agregado.....");
            else
                MessageBox.Show("No se pudo agregar el registro...");
        }

    }
}
