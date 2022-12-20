using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGrafica.Formulario_Crud_Personas;
using Entidades;
using Entidades.Listas;
using Entidades.BaseDeDatos;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Personas;

namespace InterfazGrafica.Formulario_Crud_Barcos
{
    public partial class Frm_ListarTripulantes : Frm_ListarPersonas
    {
        private Almacenamiento<Persona> listaTripulantes;

        private Frm_ListarTripulantes()
        {
            InitializeComponent();
        }

        public Frm_ListarTripulantes(Almacenamiento<Persona> lista) : this()
        {
            this.listaTripulantes = lista;
        }

        private void Frm_ListarTripulantes_Load(object sender, EventArgs e)
        {
            this.ListarPersonas(this.listaTripulantes);
        }
    }
}
