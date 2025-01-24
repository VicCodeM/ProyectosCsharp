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
        private void MostrarFormularioEnPanel(Control panel, Control controlEmbebido)
        {
            // Limpiar cualquier control existente en el panel
            panel.Controls.Clear();

            // Configurar el control embebido para que ocupe todo el espacio del panel
            controlEmbebido.Dock = DockStyle.Fill;

            // Añadir el control embebido al panel
            panel.Controls.Add(controlEmbebido);

            // Asegurar que el control sea visible y actualizado
            controlEmbebido.BringToFront();
            controlEmbebido.Refresh();
        }



        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Crear una instancia del formulario que deseas mostrar
           FormRegistrar formularioSecundario = new FormRegistrar();

            // Llamar al método para mostrar el formulario dentro del PanelControl
             MostrarFormularioEnPanel(panelControl1, formularioSecundario);
           // Form testForm = new Form
          //  {
          //      BackColor = Color.Red // Solo para verificar visualmente
          //  };
        //    MostrarFormularioEnPanel(panelControl1, testForm);

        }

        private void panelControl1_SizeChanged(object sender, EventArgs e)
        {
            if (panelControl1.Controls.Count > 0)
            {
                var controlEmbebido = panelControl1.Controls[0];
                controlEmbebido.Dock = DockStyle.Fill;
                controlEmbebido.Refresh();
            }
        }
    }
}
