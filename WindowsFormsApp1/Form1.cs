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
using System.Resources;
namespace CRUD_Basico
{   
    public partial class frmdatos : Form
    {
        clientes datos = new clientes();
        DataTable db = new DataTable();
        public frmdatos()
        {
            InitializeComponent();
            listadatos.RowTemplate.Height = 40;
            listadatos.RowHeadersDefaultCellStyle.ForeColor = Color.Blue;
            DateTime hoy = DateTime.Today;
            fechatxt.Text =   hoy.ToLongDateString().ToUpper();
            datos.conectar();
            datos.cargar(ref listadatos);
            inforeg.Text = "Total registros: " + listadatos.RowCount.ToString();
            buscar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            insertar frminsertar = new insertar(listadatos, inforeg);
            frminsertar.Show();

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
                txtbuscar.Text = "";
                datos.cargar(ref listadatos);
                MessageBox.Show("Registro eliminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inforeg.Text = "Total registros: " + listadatos.RowCount.ToString();
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

        private void buscar()
        {
            db.Columns.Add("id");
            db.Columns.Add("Nombre");
            db.Columns.Add("Apellidos");
            for (int i = 0; i <= listadatos.RowCount - 1; i++)
            {
                DataRow dr = db.NewRow();
                dr[0] = listadatos.Rows[i].Cells[0].Value.ToString();
                dr[1] = listadatos.Rows[i].Cells[1].Value.ToString();
                dr[2] = listadatos.Rows[i].Cells[2].Value.ToString();
                db.Rows.Add(dr);
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(db);
            dv.RowFilter = "nombre LIKE '" + txtbuscar.Text + "*' OR apellidos LIKE '" + txtbuscar.Text + "*'";
            listadatos.DataSource = dv;
            listadatos.Columns[0].Visible = false;
            inforeg.Text = "Total registros: " + dv.Count;            
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Flat,Border3DSide.All);
        }

        private void fechatxt_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Bump, Border3DSide.Left);
        }
    }
}
