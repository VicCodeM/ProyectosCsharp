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

namespace ODS.Forms
{
    public partial class FormRegistrar : DevExpress.XtraEditors.XtraUserControl
    {
        public FormRegistrar()
        {
            InitializeComponent();
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
            }
        }
     
        }
}

