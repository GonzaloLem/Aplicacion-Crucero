using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Operaciones;

namespace InterfazGrafica.Funciones_Extras
{
    public static class Extras
    {

        public static void Limpiar(Control control)
        {
            foreach(Control item in control.Controls)
            {
                if(item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }

                if(item is ComboBox)
                {
                    ((ComboBox)item).SelectedItem = null;
                }

                if(item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
            }
        }
    }
}
