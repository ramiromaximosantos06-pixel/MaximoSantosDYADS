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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        public void Actualizar()
        {
            RegistrosBD oRegistrosDB = new RegistrosBD();
            dataGridView1.DataSource = oRegistrosDB.Get();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
            Actualizar();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int? GetId()

        {
            try
            {

                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                Form2 frm = new Form2((int)Id);

                frm.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int? Id = GetId();
                if (Id != null)
                {
                    RegistrosBD oRegistrosDB = new RegistrosBD();
                    oRegistrosDB.Eliminar((int)Id);
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro " + ex.Message);
            }
        }
    }
    
}
