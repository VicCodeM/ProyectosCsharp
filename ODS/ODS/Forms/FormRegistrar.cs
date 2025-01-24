using DevExpress.XtraEditors;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ODS.Forms
{
    public partial class FormRegistrar : DevExpress.XtraEditors.XtraUserControl
    {
        public FormRegistrar()
        {
            InitializeComponent();
            // Configurar el formulario para adaptarse correctamente
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0); // Elimina márgenes adicionales
           // this.AutoScaleMode = AutoScaleMode.None; // Desactivar el escalado automático si es innecesario
            ConexionDB conexionDB = new ConexionDB();
            SqlConnection conexion = conexionDB.ConectarSQL();

            // Verificar si la conexión está abierta
            if (conexion.State == ConnectionState.Open)
            {
                XtraMessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Aquí puedes ejecutar consultas o realizar operaciones con la base de datos
                // Por ejemplo:
                using (SqlCommand command = new SqlCommand("SELECT * FROM Login", conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        XtraMessageBox.Show($"ID: {reader["Id_Usuario"]}, Nombre: {reader["Usuario"]}");
                    }
                }

                UpdateControls(checkEdit1.Checked, checkEdit2.Checked);

            }

        }

        private void UpdateControls(bool isCheckEdit1Checked, bool isCheckEdit2Checked)
        {
            // Si checkEdit1 está marcado
            if (isCheckEdit1Checked)
            {
                checkEdit2.Checked = false;
                checkEdit2.Enabled = false;
                dateTimeOffsetEdit2.Enabled = false;
            }
            else
            {
                checkEdit2.Enabled = true;
                dateTimeOffsetEdit2.Enabled = true;
            }

            // Si checkEdit2 está marcado
            if (isCheckEdit2Checked)
            {
                checkEdit1.Checked = false;
                checkEdit1.Enabled = false;
                dateTimeOffsetEdit1.Enabled = false;
            }
            else
            {
                checkEdit1.Enabled = true;
                dateTimeOffsetEdit1.Enabled = true;
            }
        }



    }
}

