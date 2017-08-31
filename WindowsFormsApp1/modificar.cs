using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Basico
{
    public partial class modificar : Form
    {
        private string nombre;
        private string apellidos;
        private int id;
        private DataGridView listadatos;
        private clientes datos;

        public modificar(string nombre, string apellidos, int id, DataGridView listadatos)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.id = id;
            this.listadatos = listadatos;
            txtnombre.Text = nombre;
            txtapellidos.Text = apellidos;
        }

        private void modificar_Load(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
                clientes datos = new clientes();
                datos.modificar(id, txtnombre.Text, txtapellidos.Text);
                datos.cargar(ref listadatos);
                this.Close();
        }
    }
}
