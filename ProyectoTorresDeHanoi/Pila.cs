using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTorresDeHanoi
{
    public class Pila<T>
    {
        int count ;//contador
        int x;
        private Nodo<T> auxiliar; //esta variable de referencia nos ayuda a trabajar con pilas 
        private Nodo<T> inicio;//El ancla o encabezado de la pila
        public Pila(int x)
        {
            inicio = new Nodo<T>();
            inicio.Siguiente = null;
            count = 0;
            this.x = x;
        }

        /// <summary>
        /// Apila un objeto en la Pila
        /// </summary>
        /// <param name="disk"></param>
        public void Push(T disk)
        {
            Nodo<T> tem = new Nodo<T>();
            tem.Dato = disk;
            tem.Siguiente = inicio.Siguiente;
            inicio.Siguiente = tem;
            count++;

        }

        /// <summary>
        /// Desapila un objeto de la Pila
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T seleccionado = default(T) ;
            if (inicio.Siguiente != null)
            {
                //obtenemos el dato correspondiente
                auxiliar = inicio.Siguiente;
                seleccionado = auxiliar.Dato;
                //sacamos dato de la pila
                inicio.Siguiente = auxiliar.Siguiente;
                auxiliar.Siguiente = null;
                count--;
            }
          
            return seleccionado;
        }

        /// <summary>
        /// Limpia la Pila 
        /// </summary>
        public void Clear()
        {
            while (count >0)
            {
                Pop();
                count=0;
            }
        }

        /// <summary>
        /// Devuelve el ultimo objeto de la Pila pero sin desapilarlo
        /// </summary>
        /// <returns>Devuelve el utimo objeto</returns>
        public T Peek()
        {
            T seleccionado = default(T);
            if (inicio.Siguiente != null)
            {
                //obtenemos el dato correspondiente
                auxiliar = inicio.Siguiente;
                seleccionado = auxiliar.Dato;
            }
            return seleccionado;
        }

        /// <summary>
        /// Indica si el objeto se encuentra dentro de la Pila
        /// </summary>
        /// <param name="buscado"></param>
        /// <returns></returns>
        public bool Contains(T buscado)
        {
            Nodo<T> desplazo = inicio;
            while (desplazo != null)
            {
                if (buscado.Equals( inicio.Dato))
                {
                    return true;
                }
                desplazo = desplazo.Siguiente;
            }
            return false;
        }
      
        public int X {get{return x; } }
        public int Count { get { return count; } }
      
    }
}