namespace RegistrosSqlPractica
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblNombre2 = new System.Windows.Forms.Label();
            this.LblApellido2 = new System.Windows.Forms.Label();
            this.TxtNombre2 = new System.Windows.Forms.TextBox();
            this.Txtpellido2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LblNombre2
            // 
            this.LblNombre2.AutoSize = true;
            this.LblNombre2.Location = new System.Drawing.Point(33, 38);
            this.LblNombre2.Name = "LblNombre2";
            this.LblNombre2.Size = new System.Drawing.Size(44, 13);
            this.LblNombre2.TabIndex = 0;
            this.LblNombre2.Text = "Nombre";
            // 
            // LblApellido2
            // 
            this.LblApellido2.AutoSize = true;
            this.LblApellido2.Location = new System.Drawing.Point(33, 93);
            this.LblApellido2.Name = "LblApellido2";
            this.LblApellido2.Size = new System.Drawing.Size(44, 13);
            this.LblApellido2.TabIndex = 1;
            this.LblApellido2.Text = "Apellido";
            // 
            // TxtNombre2
            // 
            this.TxtNombre2.Location = new System.Drawing.Point(99, 38);
            this.TxtNombre2.Name = "TxtNombre2";
            this.TxtNombre2.Size = new System.Drawing.Size(100, 20);
            this.TxtNombre2.TabIndex = 2;
            // 
            // Txtpellido2
            // 
            this.Txtpellido2.Location = new System.Drawing.Point(99, 93);
            this.Txtpellido2.Name = "Txtpellido2";
            this.Txtpellido2.Size = new System.Drawing.Size(100, 20);
            this.Txtpellido2.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Txtpellido2);
            this.Controls.Add(this.TxtNombre2);
            this.Controls.Add(this.LblApellido2);
            this.Controls.Add(this.LblNombre2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNombre2;
        private System.Windows.Forms.Label LblApellido2;
        private System.Windows.Forms.TextBox TxtNombre2;
        private System.Windows.Forms.TextBox Txtpellido2;
    }
}