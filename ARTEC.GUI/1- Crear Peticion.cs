using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARTEC.GUI
{
    public partial class _1__Crear_Peticion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public _1__Crear_Peticion()
        {
            InitializeComponent();
        }

        private void cboxExpediente_CheckedChanged(object sender, EventArgs e)
        {
            //Prueba
            cboxExpediente.Visible = false;
            cboxExpediente.Enabled = false;
            txtExpediente.Visible = true;
            txtExpediente.Enabled = true;
            txtExpediente.Text = DateTime.Today.DayOfYear.ToString();
        }
    }
}
