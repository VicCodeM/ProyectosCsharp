using DevExpress.XtraBars;
using ODS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ODS
{
    public partial class FormInicial : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FormInicial()
        {
            InitializeComponent();

        }
        private void MostrarFormularioEnPanel(Control panel, Control formulario)
        {
            panel.Controls.Clear();
            formulario.Dock = DockStyle.Fill;
            panel.Controls.Add(formulario);

            if (formulario is DevExpress.XtraEditors.XtraForm)
            {
                ((DevExpress.XtraEditors.XtraForm)formulario).TopLevel = false;
                ((DevExpress.XtraEditors.XtraForm)formulario).FormBorderStyle = FormBorderStyle.None;
                ((DevExpress.XtraEditors.XtraForm)formulario).Show();
            }
            else if (formulario is Form)
            {
                ((Form)formulario).TopLevel = false;
                ((Form)formulario).FormBorderStyle = FormBorderStyle.None;
                ((Form)formulario).Show();
            }
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que deseas mostrar
            FormRegistrar formularioSecundario = new FormRegistrar();

            // Llamar al método para mostrar el formulario dentro del PanelControl
            MostrarFormularioEnPanel(panelControl1, formularioSecundario);
        }
    }
}
