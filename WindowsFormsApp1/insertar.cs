using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUD_Basico
{
    public partial class insertar : Form
    {
        private DataGridView listadatos;
      
        public insertar(DataGridView listadatos)
        {
            
            InitializeComponent();
            this.listadatos = listadatos;
        }

        private void insertar_Load(object sender, EventArgs e)
        {
        
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientes datos = new clientes();
            bool correcto = datos.Comprobar(txtnombre.Text, txtapellidos.Text);
            if (correcto)
                {
                    datos.insertar(txtnombre.Text, txtapellidos.Text);
                    datos.cargar(ref listadatos);
                    this.Close();
                }
        }

  
    }
}
