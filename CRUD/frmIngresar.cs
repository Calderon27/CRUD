using System;
using System.Text.RegularExpressions;
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
        public static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TIC.DatosPersona persona = new TIC.DatosPersona();
            if ((string.IsNullOrEmpty(txtCedula.Text)) || (string.IsNullOrEmpty(txtApellidos.Text)) || (string.IsNullOrEmpty(txtNombres.Text)))
            {
                MessageBox.Show("Por favor llenar dato obligatoriamente...");
            }
            else
            {
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
                if (ComprobarFormatoEmail(txtCorreo.Text) == false)
                {
                    MessageBox.Show("Correo no valido por favor ingresar con el formato adecuado..");
                    this.txtCorreo.Text = "";
                }
                else
                {                 
                    int x = TIC.DatosPersonasDAO.crear(persona);
                    if (x > 0)
                        MessageBox.Show("Registro agregado exitosamente.....");
                    else
                        MessageBox.Show("No se pudo agregar el registro...");
                }
                   
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtCedula.Text = "";
            txtCedula.Focus();
            this.txtApellidos.Text = "";
            this.txtNombres.Text = "";
            this.txtCorreo.Text = "";
            cmbSexo.DataSource = null;
            this.txtEstatura.Text = "";
            this.txtPeso.Text = "";
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (txtCedula.TextLength >= 10)
            {
                MessageBox.Show("Llegastes al maximo de caracteres");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) ;
        }
    }
}
