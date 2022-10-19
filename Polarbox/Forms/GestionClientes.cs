using Polarbox.dao;
using System;
using System.Collections.Generic;
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
        //Boton editar
        private void button1_Click(object sender, EventArgs e)
        {

            if( listClientes.SelectedItems.Count == 0 )// Controla que tenemos algun elemento del listbox seleccionado
            {
                MessageBox.Show("Debe selecionar algun elemento");
            }
            else
            {
                editarCampos();
            }
            
        }
        private void editarCampos()
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
            string dni = txtDni.Text;

            if (comprobarDni(dni) == true && dni.Length == 9)
            {
                if (lblId.Text != "")
                {
                    cliente.Id = lblId.Text;
                }

                ClienteDao basdeDeDatos = new ClienteDao();
                basdeDeDatos.Guardar(cliente);
                actualizarLista();
                limpiarCampos();

            }
            else
                MessageBox.Show("Debes introducir un DNI correcto");


            
        }
        private string calcularLetraDni(int numeroDni)
        {
            string[] control = { "T", "R", "W", "A", "G", "M", "Y", "F", "P", "D", "X", "B", "N",
                "J", "Z", "S", "Q", "V", "H", "L", "C", "K", "E" };
            int modulo = numeroDni % 23;
            return control[modulo];

        }
        private bool comprobarDni(string dni)
        {
            try
            {
                int numerosDni = Int32.Parse(dni.Substring(0, 8));
                string letraDni = dni.Substring(dni.Length - 1, 1);


                string letraDniCalculado = calcularLetraDni(numerosDni);

                if (letraDni.ToUpper() == letraDniCalculado && dni.Length == 9)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;

                
            }
            
            
        }
        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtDni.Text = "";
            lblId.Text = "";
        }
        public void actualizarLista()
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
        public bool existeDniDb()
        {
            ClienteDao basdeDeDatos = new ClienteDao();
            List<Cliente> listaDb = basdeDeDatos.ObtenerlistadoDeClientes();

            listClientes.Items.Clear();

            for (int i = 0; i < listaDb.Count; i++)
            {
                Cliente cliente = listaDb[i];
                listClientes.Items.Add(cliente);
            }


            return true;
        }

        //Boton eliminar
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listClientes.SelectedItems.Count == 0)// Controla que tenemos algun elemento del listbox seleccionado
            {
                MessageBox.Show("Debe selecionar algun elemento");
            }
            else
            {
                Cliente cliente = (Cliente)listClientes.SelectedItem;
                ClienteDao baseDeDatos = new ClienteDao();

                baseDeDatos.Eliminar(cliente);
                actualizarLista();
            }
           
        }

        private void listClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
