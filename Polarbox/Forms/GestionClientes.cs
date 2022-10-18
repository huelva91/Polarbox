using Polarbox.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polarbox
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizarLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;
            txtNombre.Text = cliente.Nombre;
            txtApellidos.Text = cliente.Apellidos;
            txtDni.Text = cliente.Dni;
            lblId.Text = cliente.Id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellidos = txtApellidos.Text;
            cliente.Dni = txtDni.Text;

            if (lblId.Text != "")
            {
                cliente.Id = lblId.Text;
            }


            ClienteDao basdeDeDatos = new ClienteDao();
            basdeDeDatos.Guardar(cliente);
            actualizarLista();
            limpiarCampos();
        }
        private bool comprobarDni()
        {
            return true;
        }
        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDni.Text = "";
            lblId.Text = "";
        }
        private void actualizarLista()
        {
            ClienteDao basdeDeDatos = new ClienteDao();
            List<Cliente> listaDb = basdeDeDatos.ObtenerlistadoDeClientes();

            listClientes.Items.Clear();

            for (int i = 0; i < listaDb.Count; i++)
            {
                Cliente cliente = listaDb[i];
                listClientes.Items.Add(cliente);
            }
           

        }
        //Boton eliminar
        private void button1_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)listClientes.SelectedItem;
            ClienteDao baseDeDatos = new ClienteDao();


            baseDeDatos.Eliminar(cliente);
            actualizarLista();
        }
    }
}
