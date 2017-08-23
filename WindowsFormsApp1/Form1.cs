using System;
using System.Data.OleDb;
using System.IO;
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
   
    public partial class frmdatos : Form
    {
        clientes datos = new clientes();
        public frmdatos()
        {
            InitializeComponent();
            listadatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            listadatos.RowTemplate.Height = 30;
            listadatos.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            datos.conectar();
            datos.cargar(ref listadatos);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.Text = "Gestion personas";
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            insertar frminsertar = new insertar(listadatos);
            frminsertar.Show();

        }

        private void listadatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (listadatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccionar una fila de la tabla para eliminar registro", "Atención!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                int id = Int32.Parse(listadatos.SelectedRows[0].Cells[0].Value.ToString());
                datos.borrar(id);
                datos.cargar(ref listadatos);
                MessageBox.Show("Registro eliminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (listadatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccionar una fila de la tabla para modificar registro", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string nombre = listadatos.SelectedRows[0].Cells[1].Value.ToString();
                string apellidos = listadatos.SelectedRows[0].Cells[2].Value.ToString();
                int id = Int32.Parse(listadatos.SelectedRows[0].Cells[0].Value.ToString());
                modificar frmodificar = new modificar(nombre, apellidos,id, listadatos);
                frmodificar.Show();
            }
         }
    }
}
