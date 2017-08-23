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
    class clientes
    {
        private OleDbConnection conn;
        private string path = Application.StartupPath + "\\datos.accdb";

        public void conectar()
        {
            if (File.Exists(path))
            {
                try
                {
                    string conpath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
                    conn = new OleDbConnection(conpath);
                    conn.Open();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se encuentra el archivo con la base de datos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertar(string nombre, string apellidos)
        {
            conectar();
            OleDbCommand sql = new OleDbCommand("INSERT INTO clientes (nombre,apellidos) values ('" + nombre + "','" + apellidos + "')");
            sql.Connection = conn;
            sql.ExecuteNonQuery();
            conn.Close();
        }

        public void borrar(int id)
        {
            conectar();
            OleDbCommand sql = new OleDbCommand("DELETE FROM clientes WHERE id=?");
            sql.Parameters.AddWithValue("id", id);
            sql.Connection = conn;
            sql.ExecuteNonQuery();
            conn.Close();
        }

        public void cargar(ref DataGridView lista)
        {
            string query = "SELECT * FROM clientes;";
            OleDbCommand sql = new OleDbCommand(query, conn);
            OleDbDataAdapter odadatos = new OleDbDataAdapter(sql);
            DataSet clientes = new DataSet();
            odadatos.Fill(clientes);
            lista.DataSource = clientes.Tables[0];
            lista.Columns[0].Visible = false;
            conn.Close();
        }
    }

}

