using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ArbolDLL
{
    public class ArbolB
    {
        public Node Raiz { get; set; }

        public ArbolB()//Inicia vacio el arbol
        {
            Raiz = null;
        }

        public void Insertar(string valornodo)
        {
            if (Raiz == null)//Si no hay nada crea la raiz y ya que es el primer nodo se vuelve la raiz 
            {
                Raiz = new Node(valornodo);
                return;
            }
            Node Nodoactual = Raiz;
            Node padre = null; //Ya que es la raiz no tiene padre
            while (Nodoactual != null) //Si no es el que acabamos de insertar
            {
                if (Nodoactual.Llaves.Count == 3)
                {
                    if (padre == null)
                    {
                        string temporal = Nodoactual.Remover(1);
                        Node nuevaRaiz = new Node(temporal);
                        Node[] newNodos = Nodoactual.Dividir();
                        nuevaRaiz.InsertarALaPar(newNodos[0]);
                        nuevaRaiz.InsertarALaPar(newNodos[1]);
                        Raiz = nuevaRaiz;
                        Nodoactual = nuevaRaiz;
                    }
                    else if (padre != null)
                    {

                        string temp = Nodoactual.Remover(1);
                        if (temp != null)
                        {
                            padre.AgregarValorNodo(temp);
                        }
                        Node[] nNodos = Nodoactual.Dividir();
                        int pos1 = padre.UltimoNodo(nNodos[1].Llaves[0]);
                        padre.InsertarALaPar(nNodos[1]);
                        int posActual = padre.UltimoNodo(valornodo);
                        Nodoactual = padre.ObtenerOrilla(posActual);

                    }
                }
                padre = Nodoactual;
                Nodoactual = Nodoactual.Traverse(valornodo);
                if (Nodoactual == null)
                {
                    padre.AgregarValorNodo(valornodo);
                }
            }
        }
        public Node Buscar(string k)
        {
            Node temp = Raiz;

            while (temp != null)
            {
                if (temp.Existe(k) >= 0)
                {
                    return temp;
                }
                else
                {
                    int p = temp.UltimoNodo(k);
                    temp = temp.ObtenerOrilla(p);
                }
            }

            return null;
        }
        public void Eliminar(string k)
        {

            Node temp = Raiz;
            Node padre = null;
            while (temp != null)
            {
                if (temp.Llaves.Count == 1)
                {
                    if (temp != Raiz)
                    {
                        string primero = temp.Llaves[0];
                        int pos = padre.UltimoNodo(primero);

                        bool? obtenerNodeDer = null;
                        Node hermano = null;

                        if (pos > -1)
                        {
                            if (pos < 3)
                            {
                                hermano = padre.ObtenerOrilla(pos + 1);
                                if (hermano.Llaves.Count > 1)
                                {
                                    obtenerNodeDer = true;
                                }
                            }

                            if (obtenerNodeDer == null && pos > 0)
                            {
                                hermano = padre.ObtenerOrilla(pos - 1);
                                if (hermano.Llaves.Count > 1)
                                {
                                    obtenerNodeDer = false;
                                }
                            }

                            if (obtenerNodeDer != null)
                            {
                                string tempquitar = "";
                                string guardareliminado = "";

                                if (obtenerNodeDer.Value)
                                {
                                    tempquitar = padre.Remover(pos);
                                    guardareliminado = hermano.Remover(0);

                                    if (hermano.Hijos.Count > 0)
                                    {
                                        Node edge = hermano.EliminarO(0);
                                        temp.InsertarALaPar(edge);
                                    }
                                }
                                else
                                {
                                    tempquitar = padre.Remover(pos);
                                    guardareliminado = hermano.Remover(hermano.Llaves.Count - 1);

                                    if (hermano.Hijos.Count > 0)
                                    {
                                        Node edge = hermano.EliminarO(hermano.Hijos.Count - 1);
                                        temp.InsertarALaPar(edge);
                                    }
                                }

                                padre.AgregarValorNodo(guardareliminado);
                                temp.AgregarValorNodo(tempquitar);
                            }
                            else
                            {
                                string tempeliminado = null;
                                if (padre.Hijos.Count >= 2)
                                {
                                    if (pos == 0)
                                    {
                                        tempeliminado = padre.Remover(0);
                                    }
                                    else if (pos == padre.Hijos.Count)
                                    {
                                        tempeliminado = padre.Remover(padre.Llaves.Count - 1);
                                    }
                                    else
                                    {
                                        tempeliminado = padre.Remover(1);
                                    }

                                    if (tempeliminado != null)
                                    {
                                        temp.AgregarValorNodo(tempeliminado);
                                        Node sib = null;
                                        if (pos != padre.Hijos.Count)
                                        {
                                            sib = padre.EliminarO(pos + 1);
                                        }
                                        else
                                        {
                                            sib = padre.EliminarO(padre.Hijos.Count - 1);
                                        }

                                        temp.UnirNodosHijo(sib);
                                    }
                                }
                                else
                                {
                                    //  temp.UltimoNodo(padre, hermano);
                                    Raiz = temp;
                                    padre = null;
                                }
                            }
                        }
                    }
                }

                if ((temp.Existe(k)) >= 0)
                {

                    if (temp.Hijos.Count == 0)
                    {
                        if (temp.Llaves.Count == 0)
                        {
                            padre.Hijos.Remove(temp);
                        }
                    }
                    else
                    {
                        Node n = null;
                        if (n == null)
                        {
                            n = Raiz;
                        }
                        Node temp2 = n;
                        if (n != null)
                        {

                            while (n.Hijos.Count > 0)
                            {
                                temp2 = n.Hijos[0];
                            }
                        }

                        Node nextnodo = temp2;
                        string sK = nextnodo.Llaves[0];
                        if (nextnodo.Llaves.Count > 1)
                        {
                            nextnodo.Remover(0);
                        }
                        else
                        {
                            if (nextnodo.Hijos.Count == 0)
                            {
                                Node p = nextnodo.Padre;
                                p.EliminarO(nextnodo);
                            }
                            else
                            {

                            }
                        }
                    }

                    temp = null;
                }
                else
                {
                    int p = temp.UltimoNodo(k);
                    padre = temp;
                    temp = temp.ObtenerOrilla(p);
                }
            }

        }


    }
}
