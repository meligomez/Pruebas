using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class Compra
    {
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public string tipoDcumentoCliente { get; set; }
        public int numeroDocumentoCliente { get; set; }
        public int factura { get; set; }
        public int tarjetaID { get; set; }
        public int precio { get; set; }
        public int puntosID { get; set; }
        public int ubicacionID { get; set; }


        public Tarjeta tar { get; set; }
        public Cliente cli { get; set; }
        public Ubicacion ub { get; set; }
       

    }
}
