using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Controladora;
using Entidades;

namespace Vista
{
    public partial class Form1 : Form
    {
        private List<Movimiento> listaAuxMovimientos = new List<Movimiento>();
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientesCombo();
            RellenarGrillaCuentas();
        }

        private void CargarClientesCombo()
        {
            var items = Controladora.Controladora.Instancia
                .ListarCliente()
                .Select(c => new
                {
                    Id = c.ClienteId,
                    NombreCompleto = $"{c.Apellido}, {c.Nombre}"
                })
                .ToList();

            cmbClientes.DataSource = null;
            cmbClientes.DataSource = items;
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Id";


        }
        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CLICK DETECTADO");

        }

        private void RellenarGrillaCuentas()
        {
            Dgv1.DataSource = null;
            Dgv1.DataSource = Controladora.Controladora.Instancia
           .ListarCuentas()
           .Select(c => new
           {
               c.CuentaCorrienteId,
               c.NumeroCuenta,
               Cliente = c.Cliente != null ? $"{c.Cliente.Apellido}, {c.Cliente.Nombre}" : "(s/cliente)",
               c.saldo
           })
               .ToList();
        }
        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregarCuenta_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue == null)
            {
                MessageBox.Show("elegi un cliente plz");
                return;
            }
            var cuenta = new CuentaCorriente
            {
                NumeroCuenta = txtNumeroCuenta.Text,
                ClienteId = (int)cmbClientes.SelectedValue
            };

            var msg = Controladora.Controladora.Instancia.AgregarCuenta(cuenta);
            MessageBox.Show(msg);
            RellenarGrillaCuentas();
            cmbClientes.Focus();
            cmbClientes.SelectedItem = null;
            txtNumeroCuenta.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Dgv1.CurrentRow == null)
            {
                return;
            }
            int CuentaId = (int)Dgv1.CurrentRow.Cells["CuentaCorrienteId"].Value;

            Dgv2.DataSource = null;
            Dgv2.DataSource = Controladora.Controladora.Instancia
                .ListarMovimientos(CuentaId)
                .Select(m => new
                {
                    m.Fecha,
                    m.Descripcion,
                    m.Tipo,
                    m.Monto,

                })
                .ToList();

            var resumen = Controladora.Controladora.Instancia.ObtenerResumenCuenta(CuentaId);
            LblTotalDebitos.Text = resumen.totalDebitos.ToString("N2");
            LblTotalCreditos.Text = resumen.totalCreditos.ToString("N2");
            LblTotalSaldo.Text = resumen.Saldo.ToString("N2");
        }

        private void BtnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            if (Dgv1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cuenta primero.");
                return;
            }
            int CuentaId = (int)Dgv1.CurrentRow.Cells["CuentaCorrienteId"].Value;
            var movimiento = new Movimiento
            {
                CuentaCorrienteId = CuentaId,
                Fecha = Dtp1.Value,
                Descripcion = txtDescripcionMov.Text,
                Monto = decimal.TryParse(txtMontoMov.Text, out var m) ? m : 0m,
                Tipo = RbDebito.Checked ? TipoMovimiento.debito : TipoMovimiento.credito
            };

            var msg = Controladora.Controladora.Instancia.AgregarMovimiento(movimiento);
            MessageBox.Show(msg);
            dataGridView1_SelectionChanged(null, null);
        }

        private void BtnAgregarCliente_Click_1(object sender, EventArgs e)
        {
            var cli = new Cliente
            {
                Nombre = txtNombreCliente.Text,
                Apellido = txtApellidoCliente.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text
            };
            string mensaje = Controladora.Controladora.Instancia.AgregarCliente(cli);
            MessageBox.Show(mensaje);
            CargarClientesCombo();
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtNombreCliente.Focus();
        }
        private void CargarMovimientosYResumen(int cuentaId)
        {

            Dgv2.DataSource = null;
            Dgv2.DataSource = Controladora.Controladora.Instancia
                .ListarMovimientos(cuentaId)
                .Select(m => new
                {
                    m.Fecha,
                    m.Descripcion,
                    m.Tipo,
                    m.Monto
                })
                .ToList();


            var (totalDebitos, totalCreditos, saldo) =
                Controladora.Controladora.Instancia.ObtenerResumenCuenta(cuentaId);

            LblTotalDebitos.Text = totalDebitos.ToString("N2");
            LblTotalCreditos.Text = totalCreditos.ToString("N2");
            LblTotalSaldo.Text = saldo.ToString("N2");
        }
        private void LblTotalSaldo_Click(object sender, EventArgs e)
        {

        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            int cuentaId = (int)Dgv1.Rows[e.RowIndex].Cells["CuentaCorrienteId"].Value;

            // Confirmar con el usuario
            var confirm = MessageBox.Show(
                "¿Estás seguro de que querés eliminar esta cuenta?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                string msg = Controladora.Controladora.Instancia.EliminarCuenta(cuentaId);
                MessageBox.Show(msg);

                // Actualizar la grilla
                RellenarGrillaCuentas();
            }
        }

        private void BtnVerMovimientos_Click(object sender, EventArgs e)
        {
            if (Dgv1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una cuenta primero.");
                return;
            }

            var idObj = Dgv1.CurrentRow.Cells["CuentaCorrienteId"].Value;
            if (idObj == null) return;

            int cuentaId = Convert.ToInt32(idObj);
            CargarMovimientosYResumen(cuentaId);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
