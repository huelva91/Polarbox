using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polarbox
{
    class Cliente
    {
        private string id;
        private string nombre;
        private string apellidos;
        private string dni;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }

        public string NombreCompleto
        {
            get { return Nombre +" " + Apellidos;  }
        }
        public override string ToString()
        {
            return NombreCompleto.ToString();
        }
    }
}
