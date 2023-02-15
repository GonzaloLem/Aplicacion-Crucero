using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Personas;
using Entidades.Listas;
using Entidades.BaseDeDatos;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Extensiones;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_ListarPersonas : Form
    {
        private Almacenamiento<Persona> lista;
        private ListSortDirection orden;
        public Frm_ListarPersonas()
        {
            InitializeComponent();

            this.lista = new Almacenamiento<Persona>(Persona.Comparar);
            this.orden = ListSortDirection.Ascending;
        }

        public Frm_ListarPersonas(Almacenamiento<Persona> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        #region Eventos
        private void Frm_ListarPersonas_Load(object sender, EventArgs e)
        {

            this.lista += ConexionSQLPersona.Obtener();
            this.ListarPersonas(this.lista);

            this.dtGdVw_ListarPersonas.Sort(this.Colum_Personas_Id, ListSortDirection.Ascending);

        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (this.dtGdVw_ListarPersonas.SelectedRows.Count == 1)
            {
                Persona tripulante = null;

                if ((string)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[7].Value == "Pasajero")
                {
                    tripulante = (Pasajero)ConexionSQLPersona.Obtener_Persona((int)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[0].Value);
                }
                else if ((string)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[7].Value == "Empleado")
                {
                    tripulante = (Empleado)ConexionSQLPersona.Obtener_Persona((int)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[0].Value);
                }
                else if ((string)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[7].Value == "Capitan")
                {
                    tripulante = (Capitan)ConexionSQLPersona.Obtener_Persona((int)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[0].Value);
                }

                Frm_ModificarPersona formModificar = new Frm_ModificarPersona(tripulante);
                formModificar.ShowDialog();
                this.lista = ConexionSQLPersona.Obtener();
                this.ListarPersonas(this.lista);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.dtGdVw_ListarPersonas.SelectedRows.Count == 1)
            {
                ConexionSQLPersona.Eliminar(ConexionSQLPersona.Obtener_Persona((int)this.dtGdVw_ListarPersonas.Rows[this.dtGdVw_ListarPersonas.SelectedRows[0].Index].Cells[0].Value));

                this.lista = ConexionSQLPersona.Obtener();
                this.ListarPersonas(this.lista);
            }
        }
        private void btn_Filtrar_Click(object sender, EventArgs e)
        {
            if(this.txtBox_Filtro.Text != "" && this.ObtenerCheckBox() != null)
            {
                for (int i = 0; i < this.dtGdVw_ListarPersonas.Rows.Count; i++)
                {
                    this.dtGdVw_ListarPersonas.Rows[i].Visible = true;
                }

                string cadena = "Colum_Personas_";
                cadena += cadena.Rehacer(this.ObtenerCheckBox().Name, (cadena.Contar(this.ObtenerCheckBox().Name, '_') + 1));

               this.BuscarPorFiltro( this.BuscarColumnas(cadena), this.txtBox_Filtro.Text);
                
            }
        }
        #endregion
        private void BuscarPorFiltro(int index, string cadena)
        {
            for(int i=0;i<this.dtGdVw_ListarPersonas.Rows.Count;i++)
            {
                if(!this.dtGdVw_ListarPersonas.Rows[i].Cells[index].Value.ToString().Validar(this.txtBox_Filtro.Text))
                {
                    this.dtGdVw_ListarPersonas.Rows[i].Visible = false;
                }

            }
        }

        private protected void ListarPersonas(Almacenamiento<Persona> lista)
        {
            
            this.dtGdVw_ListarPersonas.Rows.Clear();

            for(int i=0;i<lista.Contar;i++)
            {
                //if(lista[i].Disponibilidad)
                
                    int index = this.dtGdVw_ListarPersonas.Rows.Add();

                    this.dtGdVw_ListarPersonas.Rows[index].Cells[0].Value = lista[i].ID;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[1].Value = lista[i].Nombre;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[2].Value = lista[i].Apellido;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[3].Value = lista[i].Edad;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[4].Value = lista[i].DNI;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[5].Value = lista[i].Nacionalidad;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[6].Value = lista[i].Celular;
                    this.dtGdVw_ListarPersonas.Rows[index].Cells[7].Value = lista[i].Tipo;
                
            }
        }

        private void Validar(object sender, EventArgs e)
        {
            string orden = "Colum_Personas_";

            foreach (Control item in this.grpBox_Ordenar.Controls)
            {
                if (item != sender)
                {
                    ((CheckBox)item).Checked = false;
                }

            }

            orden += orden.Rehacer(((CheckBox)sender).Name, orden.Contar(((CheckBox)sender).Name, '_')+ 1);

            this.OrdenarColumna(this.BuscarColumnas(orden), this.orden);
        }


        private int BuscarColumnas(string columna)
        {
            int retorno = -1;

            for(int i=0;i<this.dtGdVw_ListarPersonas.Columns.Count;i++)
            {
                if(this.dtGdVw_ListarPersonas.Columns[i].Name == columna)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
        }

        private void OrdenarColumna(int index, ListSortDirection orden)
        {
            if(index > -1)
            {
                this.dtGdVw_ListarPersonas.Sort(this.dtGdVw_ListarPersonas.Columns[index], orden);
            }
            
        }

        private CheckBox ObtenerCheckBox()
        {
            CheckBox retorno = null;

            foreach(Control item in this.grpBox_Ordenar.Controls)
            {
                if(item is CheckBox && ((CheckBox)item).Checked == true)
                {
                    retorno = (CheckBox)item;
                    break;
                }
            }

            return retorno;
        }

        private void Filtro(object sender, EventArgs e)
        {
            if(this.txtBox_Filtro.Text == "")
            {
                for (int i = 0; i < this.dtGdVw_ListarPersonas.Rows.Count; i++)
                {
                    this.dtGdVw_ListarPersonas.Rows[i].Visible = true;
                }
            }
        }

        private void VerificarOrden(object sender, EventArgs e)
        {
            if(sender == this.ckBox_Ascendente && ((CheckBox)sender).Checked == true)
            {
                this.ckBox_Descendente.Checked = false;
                this.orden = ListSortDirection.Ascending;
            }
            else
            {
                this.ckBox_Ascendente.Checked = false;
                this.orden = ListSortDirection.Descending;
            }
            if(this.ObtenerCheckBox() != null)
            {
                this.Validar(this.ObtenerCheckBox(), e);
            }
            

        }


    }
}
