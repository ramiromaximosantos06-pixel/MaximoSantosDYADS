using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrosSqlPractica
{
    public partial class Form2 : Form
    {
        private int? Id;
        public Form2(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            RegistrosBD oRegistrosBD = new RegistrosBD();
            RegistrosData oRegistrosData = oRegistrosBD.Get((int)Id);
            TxtNombre.Text = oRegistrosData.Nombre;
            TxtApellido.Text = oRegistrosData.Apellido;

        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            RegistrosBD oRegistrosDB = new RegistrosBD();
            try
            {
                if (Id == null)
                {
                    oRegistrosDB.Agregar(TxtNombre.Text, TxtApellido.Text);
                }
                else 
                { 
                    oRegistrosDB.Editar(TxtApellido.Text, TxtNombre.Text, (int)Id);
                }
                    MessageBox.Show("Guardado con exito");
                    this.Close();       
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al guardar " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TxtNombre.Select(0,0);
            TxtApellido.Select(0,0);
            TxtNombre.Focus();
            
            
        }
    }
}
