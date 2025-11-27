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
    public partial class Form3 : Form
    {
        private int? Id;
        public Form3(int? Id=null)
        {
            InitializeComponent();
           this.Id = Id;
            if(this.Id != null) 
            {
                CargarDatos();
            }
        }

        private void CargarDatos() 
        {
            RegistrosBD oRegistrosBD = new RegistrosBD();
          RegistrosData oRegistrosData =  oRegistrosBD.Get((int)Id);
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
