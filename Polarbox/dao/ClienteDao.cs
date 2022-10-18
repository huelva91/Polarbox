using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polarbox.dao
{
    class ClienteDao
    {
        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string baseDeDatos = "clientes";

            string cadenaConexion = " Database = " + baseDeDatos + " ; Data Source = "
                + servidor + " ; User Id = " + usuario + " ; Password = " + password + "";

            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);
            conexionDb.Open();

            return conexionDb;
        }
        public List<Cliente> ObtenerlistadoDeClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM `cliente`";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();

            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString("id");
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellidos = lectura.GetString("apellidos");
                cliente.Dni = lectura.GetString("dni");
                lista.Add(cliente);

            }
            comando.Connection.Close();

            return lista;

        }
        
        public void Guardar(Cliente cliente)
        {
            if( cliente.Id == null)
            {
                nuevoCliente(cliente);
            }
            else
            {
                modificarCliente(cliente);
            }

        }
        public void nuevoCliente(Cliente cliente)
        {
            string consulta = "INSERT INTO `cliente` (`id`, `nombre`, `apellidos`, `dni`)" +
                " VALUES(NULL, '" + cliente.Nombre + "', '" + cliente.Apellidos + "', '" + cliente.Dni + "');";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
        public void modificarCliente(Cliente cliente)
        {
            string consulta = "UPDATE `cliente` SET `nombre` = '"
                + cliente.Nombre + "', `apellidos` = '" + cliente.Apellidos + "', `dni` = '" + cliente.Dni + "'" +
                " WHERE `cliente`.`id` = "+cliente.Id+";";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();
            comando.Connection.Close();

        }
        public void Eliminar(Cliente cliente)
        {

            string consulta = "DELETE FROM `cliente` WHERE `cliente`.`id` = " + cliente.Id +";";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();


            comando.Connection.Close();



        }

    }
}
