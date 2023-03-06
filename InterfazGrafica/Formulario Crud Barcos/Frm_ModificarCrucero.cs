using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Barcos;

namespace InterfazGrafica.Formulario_Crud_Barcos
{
    public partial class Frm_ModificarCrucero : Frm_CrearCrucero
    {
        private Crucero crucero;
        private Frm_ModificarCrucero()
        {
            InitializeComponent();
        }

        public Frm_ModificarCrucero(Crucero crucero) : this()
        {
            this.crucero = crucero;
        }

        #region Eventos
        private void Frm_ModificarCrucero_Load(object sender, EventArgs e)
        {
            this.InicializaDatos();
        }

        private protected override void btn_CrearCrucero_Click(object sender, EventArgs e)
        {
            if (this.ValidarTexBox())
            {
                ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                Crucero crucero = new Crucero
                    (
                        this.crucero.ID,
                        this.crucero.Matricula,
                        this.txtBox_Nombre.Text,
                        int.Parse(this.txtBox_Camarotes.Text),
                        sbyte.Parse(this.txtBox_Salones.Text),
                        sbyte.Parse(this.txtBox_Casinos.Text),
                        sbyte.Parse(this.txtBox_Piscinas.Text),
                        sbyte.Parse(this.txtBox_Gimnacios.Text),
                        double.Parse(this.txtBox_Capacidad.Text),
                        this.crucero.Peso
                    );

                    conexion.Modificar(crucero);
                    this.Close();
            }
        }
        #endregion

        #region Metodos Extras

        public void InicializaDatos()
        {
            this.txtBox_Nombre.Text = crucero.Nombre;
            this.txtBox_Camarotes.Text = crucero.Camarotes.ToString();
            this.txtBox_Salones.Text = crucero.Salones.ToString();
            this.txtBox_Casinos.Text = crucero.Casinos.ToString();
            this.txtBox_Capacidad.Text = crucero.Capacidad.ToString();
            this.txtBox_Piscinas.Text = crucero.Piscinas.ToString();
            this.txtBox_Gimnacios.Text = crucero.Gimnacios.ToString();
        }

        #endregion

    }
}
