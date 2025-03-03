using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTorresDeHanoi
{
    public class Nodo<T>
    {
        private T dato;
        private Nodo<T> siguiente = null;

        public T Dato
        {
            get
            {
                return dato;
            }

            set
            {
                dato = value;
            }
        }

        internal Nodo<T> Siguiente
        {
            get
            {
                return siguiente;
            }

            set
            {
                siguiente = value;
            }
        }
    }
}
