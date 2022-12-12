using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Barcos;
using Entidades.BaseDeDatos;

namespace InterfazGrafica.Formulario_Crud_Barcos
{
    public partial class Frm_CrearCrucero : Form
    {
        public Frm_CrearCrucero()
        {
            InitializeComponent();
        }

        private void btn_CrearCrucero_Click(object sender, EventArgs e)
        {
            if (this.ValidarTexBox())
            {

                Crucero crucero = new Crucero
                    (
                        Crucero.GenerarMatricula(),
                        this.txtBox_Nombre.Text,
                        int.Parse(this.txtBox_Camarotes.Text),
                        sbyte.Parse(this.txtBox_Salones.Text),
                        sbyte.Parse(this.txtBox_Casinos.Text),
                        sbyte.Parse(this.txtBox_Piscinas.Text),
                        sbyte.Parse(this.txtBox_Gimnacios.Text),
                        double.Parse(this.txtBox_Capacidad.Text)
                    );

                if(ConexionSQLCrucero.Obtener() != crucero)
                {
                    ConexionSQLCrucero.Insertar(crucero);
                    this.Close();
                }

            }
        }


        private bool ValidarTexBox()
        {
            bool retorno = true;

                foreach(Control item in this.grpBox_Datos.Controls)
                {
                    if(item is TextBox && item != this.txtBox_Nombre)
                    {
                        if( item != this.txtBox_Capacidad && ((TextBox)item).Text != "" && int.Parse(((TextBox)item).Text) < 0)
                        {
                            retorno = false;
                        }
                        else if(((TextBox)item).Text != "" && double.Parse(((TextBox)item).Text) < 0)
                        {
                            retorno = false;
                        }

                    }
                }

            return retorno;
        }

        private void Validar(object sender, KeyPressEventArgs e)
        {
            if( !(e.KeyChar > 47 && e.KeyChar < 58 || e.KeyChar == 08))
            {
                e.Handled = true;
                return;
            }
        }

        private void Validar_SoloLetras(object sender, KeyPressEventArgs e)
        {
            if( !( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123 ) || e.KeyChar == 08 || e.KeyChar == 32 ))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
