namespace Vista
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Dgv1 = new DataGridView();
            Dgv2 = new DataGridView();
            txtNombreCliente = new TextBox();
            txtApellidoCliente = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            LblNombre = new Label();
            LblApellido = new Label();
            LblDni = new Label();
            LblTelefono = new Label();
            txtNumeroCuenta = new TextBox();
            cmbClientes = new ComboBox();
            Dtp1 = new DateTimePicker();
            txtMontoMov = new TextBox();
            txtDescripcionMov = new TextBox();
            RbDebito = new RadioButton();
            RbCredito = new RadioButton();
            BtnAgregarCliente = new Button();
            BtnAgregarCuenta = new Button();
            BtnAgregarMovimiento = new Button();
            GbClientes = new GroupBox();
            GbCuentasCorrientes = new GroupBox();
            LblNroCuenta = new Label();
            LblElegirCliente = new Label();
            GbMovimientosCuenta = new GroupBox();
            LblTipo = new Label();
            LblMonto = new Label();
            LblDescripcion = new Label();
            LblFechaMovimiento = new Label();
            GbResumen = new GroupBox();
            LblTotalSaldo = new Label();
            LblTotalCreditos = new Label();
            LblTotalDebitos = new Label();
            LblCreditos = new Label();
            LblSaldo = new Label();
            LblDebitos = new Label();
            label1 = new Label();
            BtnVerMovimientos = new Button();
            BtnSalir = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Dgv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv2).BeginInit();
            GbClientes.SuspendLayout();
            GbCuentasCorrientes.SuspendLayout();
            GbMovimientosCuenta.SuspendLayout();
            GbResumen.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv1
            // 
            Dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv1.Location = new Point(269, 18);
            Dgv1.Name = "Dgv1";
            Dgv1.Size = new Size(276, 354);
            Dgv1.TabIndex = 0;
            Dgv1.CellContentClick += Dgv1_CellContentClick;
            Dgv1.CellDoubleClick += Dgv1_CellDoubleClick_1;
            // 
            // Dgv2
            // 
            Dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv2.Location = new Point(21, 22);
            Dgv2.Name = "Dgv2";
            Dgv2.Size = new Size(276, 385);
            Dgv2.TabIndex = 1;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(134, 32);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(100, 23);
            txtNombreCliente.TabIndex = 2;
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Location = new Point(134, 63);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.Size = new Size(100, 23);
            txtApellidoCliente.TabIndex = 3;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(134, 96);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(134, 137);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 5;
            // 
            // LblNombre
            // 
            LblNombre.AutoSize = true;
            LblNombre.Location = new Point(17, 32);
            LblNombre.Name = "LblNombre";
            LblNombre.Size = new Size(92, 15);
            LblNombre.TabIndex = 6;
            LblNombre.Text = "Ingrese Nombre";
            // 
            // LblApellido
            // 
            LblApellido.AutoSize = true;
            LblApellido.Location = new Point(17, 66);
            LblApellido.Name = "LblApellido";
            LblApellido.Size = new Size(92, 15);
            LblApellido.TabIndex = 7;
            LblApellido.Text = "Ingrese Apellido";
            // 
            // LblDni
            // 
            LblDni.AutoSize = true;
            LblDni.Location = new Point(17, 104);
            LblDni.Name = "LblDni";
            LblDni.Size = new Size(66, 15);
            LblDni.TabIndex = 8;
            LblDni.Text = "Ingrese Dni";
            // 
            // LblTelefono
            // 
            LblTelefono.AutoSize = true;
            LblTelefono.Location = new Point(15, 137);
            LblTelefono.Name = "LblTelefono";
            LblTelefono.Size = new Size(94, 15);
            LblTelefono.TabIndex = 9;
            LblTelefono.Text = "Ingrese Telefono";
            // 
            // txtNumeroCuenta
            // 
            txtNumeroCuenta.Location = new Point(104, 87);
            txtNumeroCuenta.Name = "txtNumeroCuenta";
            txtNumeroCuenta.Size = new Size(100, 23);
            txtNumeroCuenta.TabIndex = 10;
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(104, 47);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(121, 23);
            cmbClientes.TabIndex = 11;
            // 
            // Dtp1
            // 
            Dtp1.Location = new Point(127, 432);
            Dtp1.Name = "Dtp1";
            Dtp1.Size = new Size(179, 23);
            Dtp1.TabIndex = 12;
            // 
            // txtMontoMov
            // 
            txtMontoMov.Location = new Point(127, 509);
            txtMontoMov.Name = "txtMontoMov";
            txtMontoMov.Size = new Size(100, 23);
            txtMontoMov.TabIndex = 13;
            // 
            // txtDescripcionMov
            // 
            txtDescripcionMov.Location = new Point(127, 469);
            txtDescripcionMov.Name = "txtDescripcionMov";
            txtDescripcionMov.Size = new Size(100, 23);
            txtDescripcionMov.TabIndex = 14;
            // 
            // RbDebito
            // 
            RbDebito.AutoSize = true;
            RbDebito.Location = new Point(127, 538);
            RbDebito.Name = "RbDebito";
            RbDebito.Size = new Size(60, 19);
            RbDebito.TabIndex = 15;
            RbDebito.TabStop = true;
            RbDebito.Text = "Débito";
            RbDebito.UseVisualStyleBackColor = true;
            // 
            // RbCredito
            // 
            RbCredito.AutoSize = true;
            RbCredito.Location = new Point(127, 563);
            RbCredito.Name = "RbCredito";
            RbCredito.Size = new Size(64, 19);
            RbCredito.TabIndex = 16;
            RbCredito.TabStop = true;
            RbCredito.Text = "Crédito";
            RbCredito.UseVisualStyleBackColor = true;
            // 
            // BtnAgregarCliente
            // 
            BtnAgregarCliente.Location = new Point(17, 181);
            BtnAgregarCliente.Name = "BtnAgregarCliente";
            BtnAgregarCliente.Size = new Size(100, 23);
            BtnAgregarCliente.TabIndex = 17;
            BtnAgregarCliente.Text = "Agregar Cliente";
            BtnAgregarCliente.UseVisualStyleBackColor = true;
            BtnAgregarCliente.Click += BtnAgregarCliente_Click_1;
            // 
            // BtnAgregarCuenta
            // 
            BtnAgregarCuenta.Location = new Point(17, 337);
            BtnAgregarCuenta.Name = "BtnAgregarCuenta";
            BtnAgregarCuenta.Size = new Size(100, 23);
            BtnAgregarCuenta.TabIndex = 18;
            BtnAgregarCuenta.Text = "Agregar Cuenta";
            BtnAgregarCuenta.UseVisualStyleBackColor = true;
            BtnAgregarCuenta.Click += BtnAgregarCuenta_Click;
            // 
            // BtnAgregarMovimiento
            // 
            BtnAgregarMovimiento.Location = new Point(189, 593);
            BtnAgregarMovimiento.Name = "BtnAgregarMovimiento";
            BtnAgregarMovimiento.Size = new Size(126, 23);
            BtnAgregarMovimiento.TabIndex = 19;
            BtnAgregarMovimiento.Text = "Agregar Movimiento";
            BtnAgregarMovimiento.UseVisualStyleBackColor = true;
            BtnAgregarMovimiento.Click += BtnAgregarMovimiento_Click;
            // 
            // GbClientes
            // 
            GbClientes.Controls.Add(LblNombre);
            GbClientes.Controls.Add(LblApellido);
            GbClientes.Controls.Add(LblDni);
            GbClientes.Controls.Add(BtnAgregarCliente);
            GbClientes.Controls.Add(LblTelefono);
            GbClientes.Controls.Add(txtTelefono);
            GbClientes.Controls.Add(txtNombreCliente);
            GbClientes.Controls.Add(txtDni);
            GbClientes.Controls.Add(txtApellidoCliente);
            GbClientes.Location = new Point(24, 12);
            GbClientes.Name = "GbClientes";
            GbClientes.Size = new Size(376, 229);
            GbClientes.TabIndex = 20;
            GbClientes.TabStop = false;
            GbClientes.Text = "CLIENTES";
            // 
            // GbCuentasCorrientes
            // 
            GbCuentasCorrientes.Controls.Add(Dgv1);
            GbCuentasCorrientes.Controls.Add(LblNroCuenta);
            GbCuentasCorrientes.Controls.Add(LblElegirCliente);
            GbCuentasCorrientes.Controls.Add(cmbClientes);
            GbCuentasCorrientes.Controls.Add(BtnAgregarCuenta);
            GbCuentasCorrientes.Controls.Add(txtNumeroCuenta);
            GbCuentasCorrientes.Location = new Point(24, 247);
            GbCuentasCorrientes.Name = "GbCuentasCorrientes";
            GbCuentasCorrientes.Size = new Size(551, 386);
            GbCuentasCorrientes.TabIndex = 21;
            GbCuentasCorrientes.TabStop = false;
            GbCuentasCorrientes.Text = "CUENTAS CORRIENTES";
            // 
            // LblNroCuenta
            // 
            LblNroCuenta.AutoSize = true;
            LblNroCuenta.Location = new Point(15, 96);
            LblNroCuenta.Name = "LblNroCuenta";
            LblNroCuenta.Size = new Size(68, 15);
            LblNroCuenta.TabIndex = 22;
            LblNroCuenta.Text = "Nro Cuenta";
            // 
            // LblElegirCliente
            // 
            LblElegirCliente.AutoSize = true;
            LblElegirCliente.Location = new Point(17, 50);
            LblElegirCliente.Name = "LblElegirCliente";
            LblElegirCliente.Size = new Size(76, 15);
            LblElegirCliente.TabIndex = 12;
            LblElegirCliente.Text = "Elegir Cliente";
            // 
            // GbMovimientosCuenta
            // 
            GbMovimientosCuenta.Controls.Add(LblTipo);
            GbMovimientosCuenta.Controls.Add(LblMonto);
            GbMovimientosCuenta.Controls.Add(LblDescripcion);
            GbMovimientosCuenta.Controls.Add(BtnAgregarMovimiento);
            GbMovimientosCuenta.Controls.Add(LblFechaMovimiento);
            GbMovimientosCuenta.Controls.Add(Dgv2);
            GbMovimientosCuenta.Controls.Add(RbCredito);
            GbMovimientosCuenta.Controls.Add(Dtp1);
            GbMovimientosCuenta.Controls.Add(RbDebito);
            GbMovimientosCuenta.Controls.Add(txtDescripcionMov);
            GbMovimientosCuenta.Controls.Add(txtMontoMov);
            GbMovimientosCuenta.Location = new Point(828, 11);
            GbMovimientosCuenta.Name = "GbMovimientosCuenta";
            GbMovimientosCuenta.Size = new Size(321, 622);
            GbMovimientosCuenta.TabIndex = 22;
            GbMovimientosCuenta.TabStop = false;
            GbMovimientosCuenta.Text = "MOVIMIENTOS DE CUENTA";
            // 
            // LblTipo
            // 
            LblTipo.AutoSize = true;
            LblTipo.Location = new Point(6, 563);
            LblTipo.Name = "LblTipo";
            LblTipo.Size = new Size(31, 15);
            LblTipo.TabIndex = 23;
            LblTipo.Text = "Tipo";
            // 
            // LblMonto
            // 
            LblMonto.AutoSize = true;
            LblMonto.Location = new Point(6, 512);
            LblMonto.Name = "LblMonto";
            LblMonto.Size = new Size(43, 15);
            LblMonto.TabIndex = 23;
            LblMonto.Text = "Monto";
            // 
            // LblDescripcion
            // 
            LblDescripcion.AutoSize = true;
            LblDescripcion.Location = new Point(6, 472);
            LblDescripcion.Name = "LblDescripcion";
            LblDescripcion.Size = new Size(69, 15);
            LblDescripcion.TabIndex = 23;
            LblDescripcion.Text = "Descripción";
            // 
            // LblFechaMovimiento
            // 
            LblFechaMovimiento.AutoSize = true;
            LblFechaMovimiento.Location = new Point(6, 440);
            LblFechaMovimiento.Name = "LblFechaMovimiento";
            LblFechaMovimiento.Size = new Size(106, 15);
            LblFechaMovimiento.TabIndex = 23;
            LblFechaMovimiento.Text = "Fecha Movimiento";
            // 
            // GbResumen
            // 
            GbResumen.Controls.Add(LblTotalSaldo);
            GbResumen.Controls.Add(LblTotalCreditos);
            GbResumen.Controls.Add(LblTotalDebitos);
            GbResumen.Controls.Add(LblCreditos);
            GbResumen.Controls.Add(LblSaldo);
            GbResumen.Controls.Add(LblDebitos);
            GbResumen.Location = new Point(416, 31);
            GbResumen.Name = "GbResumen";
            GbResumen.Size = new Size(406, 210);
            GbResumen.TabIndex = 23;
            GbResumen.TabStop = false;
            GbResumen.Text = "RESUMEN";
            // 
            // LblTotalSaldo
            // 
            LblTotalSaldo.AutoSize = true;
            LblTotalSaldo.Location = new Point(142, 126);
            LblTotalSaldo.Name = "LblTotalSaldo";
            LblTotalSaldo.Size = new Size(112, 15);
            LblTotalSaldo.TabIndex = 25;
            LblTotalSaldo.Text = "...................................";
            LblTotalSaldo.Click += LblTotalSaldo_Click;
            // 
            // LblTotalCreditos
            // 
            LblTotalCreditos.AutoSize = true;
            LblTotalCreditos.Location = new Point(142, 77);
            LblTotalCreditos.Name = "LblTotalCreditos";
            LblTotalCreditos.Size = new Size(112, 15);
            LblTotalCreditos.TabIndex = 25;
            LblTotalCreditos.Text = "...................................";
            // 
            // LblTotalDebitos
            // 
            LblTotalDebitos.AutoSize = true;
            LblTotalDebitos.Location = new Point(142, 30);
            LblTotalDebitos.Name = "LblTotalDebitos";
            LblTotalDebitos.Size = new Size(112, 15);
            LblTotalDebitos.TabIndex = 24;
            LblTotalDebitos.Text = "...................................";
            // 
            // LblCreditos
            // 
            LblCreditos.AutoSize = true;
            LblCreditos.Location = new Point(24, 77);
            LblCreditos.Name = "LblCreditos";
            LblCreditos.Size = new Size(51, 15);
            LblCreditos.TabIndex = 2;
            LblCreditos.Text = "Créditos";
            LblCreditos.Click += label3_Click;
            // 
            // LblSaldo
            // 
            LblSaldo.AutoSize = true;
            LblSaldo.Location = new Point(24, 126);
            LblSaldo.Name = "LblSaldo";
            LblSaldo.Size = new Size(36, 15);
            LblSaldo.TabIndex = 1;
            LblSaldo.Text = "Saldo";
            // 
            // LblDebitos
            // 
            LblDebitos.AutoSize = true;
            LblDebitos.Location = new Point(24, 30);
            LblDebitos.Name = "LblDebitos";
            LblDebitos.Size = new Size(47, 15);
            LblDebitos.TabIndex = 0;
            LblDebitos.Text = "Débitos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 622);
            label1.Name = "label1";
            label1.Size = new Size(307, 15);
            label1.TabIndex = 24;
            label1.Text = "PARA ELIMINAR CUENTA HACE DOBLE CLICK EN EL DGV";
            // 
            // BtnVerMovimientos
            // 
            BtnVerMovimientos.Location = new Point(581, 265);
            BtnVerMovimientos.Name = "BtnVerMovimientos";
            BtnVerMovimientos.Size = new Size(162, 23);
            BtnVerMovimientos.TabIndex = 25;
            BtnVerMovimientos.Text = "Ver movimientos de cuenta";
            BtnVerMovimientos.UseVisualStyleBackColor = true;
            BtnVerMovimientos.Click += BtnVerMovimientos_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(736, 610);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(75, 23);
            BtnSalir.TabIndex = 26;
            BtnSalir.Text = "Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 244);
            label2.Name = "label2";
            label2.Size = new Size(533, 15);
            label2.TabIndex = 27;
            label2.Text = "Tocar la cuenta a trabajar en el dgv, y si queres ver movimientos solo toca el boton ver movimientos";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 645);
            Controls.Add(label2);
            Controls.Add(BtnSalir);
            Controls.Add(BtnVerMovimientos);
            Controls.Add(label1);
            Controls.Add(GbResumen);
            Controls.Add(GbMovimientosCuenta);
            Controls.Add(GbCuentasCorrientes);
            Controls.Add(GbClientes);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Dgv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv2).EndInit();
            GbClientes.ResumeLayout(false);
            GbClientes.PerformLayout();
            GbCuentasCorrientes.ResumeLayout(false);
            GbCuentasCorrientes.PerformLayout();
            GbMovimientosCuenta.ResumeLayout(false);
            GbMovimientosCuenta.PerformLayout();
            GbResumen.ResumeLayout(false);
            GbResumen.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Dgv1;
        private DataGridView Dgv2;
        private TextBox txtNombreCliente;
        private TextBox txtApellidoCliente;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private Label LblNombre;
        private Label LblApellido;
        private Label LblDni;
        private Label LblTelefono;
        private TextBox txtNumeroCuenta;
        private ComboBox cmbClientes;
        private DateTimePicker Dtp1;
        private TextBox txtMontoMov;
        private TextBox txtDescripcionMov;
        private RadioButton RbDebito;
        private RadioButton RbCredito;
        private Button BtnAgregarCliente;
        private Button BtnAgregarCuenta;
        private Button BtnAgregarMovimiento;
        private GroupBox GbClientes;
        private GroupBox GbCuentasCorrientes;
        private Label LblNroCuenta;
        private Label LblElegirCliente;
        private GroupBox GbMovimientosCuenta;
        private Label LblTipo;
        private Label LblMonto;
        private Label LblDescripcion;
        private Label LblFechaMovimiento;
        private GroupBox GbResumen;
        private Label LblCreditos;
        private Label LblSaldo;
        private Label LblDebitos;
        private Label LblTotalSaldo;
        private Label LblTotalCreditos;
        private Label LblTotalDebitos;
        private Label label1;
        private Button BtnVerMovimientos;
        private Button BtnSalir;
        private Label label2;
    }
}
