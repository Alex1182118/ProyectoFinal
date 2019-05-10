using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolDLL
{
    public class Node
    {
        public Node Padre { get; set; }
        public List<string> Llaves { get; set; }
        public List<Node> Hijos { get; set; } //Lista ya que guarda varias claves


        public Node(string key)
        {
            Llaves = new List<string>();
            Llaves.Add(key);
            Hijos = new List<Node>();

        }

        public Node()
        {
        }

        public bool IsEmpty(List<string> LLaves)
        {
            bool empty = false;
            if (LLaves.Count == 0)
                return empty = true;
            else
                return empty;
        }

        public int Existe(string k)
        {
            for (int i = 0; i < Llaves.Count; i++)
            {
                if (string.Compare(Llaves[i], k, StringComparison.CurrentCulture) == 0)
                {
                    return 1;
                }
            }
            return -1;
        }
        public Node ObtenerOrilla(int position)
        {
            if (position < Hijos.Count)
            {
                return Hijos[position];
            }
            else
            {
                return null;
            }
        }
        public void InsertarALaPar(Node nodolado)
        {
            for (int x = 0; x < Hijos.Count; x++)
            {
                if (string.Compare(Hijos[x].Llaves[0], nodolado.Llaves[0], StringComparison.CurrentCulture) > 0)
                {
                    Hijos.Insert(x, nodolado);
                    return;
                }
            }

            Hijos.Add(nodolado);
            nodolado.Padre = this;
        }

        public void AgregarValorNodo(string temp)
        {
            if (IsEmpty(Llaves)) //Ya que esta libre solo se agrega
            {
                Llaves.Add(temp);
            }
            else
            {
                string left = " ";
                for (int i = 0; i < Llaves.Count; i++)
                {
                    if (string.Compare(left, temp, StringComparison.CurrentCulture) < 0 && string.Compare(temp, Llaves[i], StringComparison.CurrentCulture) < 0)
                    {
                        Llaves.Insert(i, temp);
                        return;
                    }
                    else
                    {
                        left = Llaves[i];
                    }
                }
                Llaves.Add(temp);
            }
        }

        public bool EliminarO(Node n)
        {
            return Hijos.Remove(n);
        }

        public Node EliminarO(int pos)
        {
            Node nodoorilla = null;
            if (Hijos.Count > pos)
            {
                nodoorilla = Hijos[pos];
                nodoorilla.Padre = null;
                Hijos.RemoveAt(pos);
            }

            return nodoorilla;
        }

        public string Remover(int pos)
        {
            if (Llaves.Count > 1)//Solo se puede si hay mas de una llave, si no se quedaria vacio
            {
                if (pos < Llaves.Count)
                {
                    string temp = Llaves[pos];
                    Llaves.RemoveAt(pos);
                    return temp;
                }

            }

            return null;
        }

        public int UltimoNodo(string k)
        {
            if (Llaves.Count == 0)
            {
                return 0;
            }
            else
            {
                string left = " ";
                for (int x = 0; x < Llaves.Count; x++)
                {
                    if (string.Compare(left, k, StringComparison.CurrentCulture) < 0 && string.Compare(k, Llaves[x], StringComparison.CurrentCulture) < 0)
                    {
                        return x;
                    }
                    else
                    {
                        left = Llaves[x];
                    }
                }

                if (string.Compare(k, Llaves[Llaves.Count - 1], StringComparison.CurrentCulture) < 0)
                {
                    return -1;
                }
                else
                {
                    return Llaves.Count; ;
                }
            }
        }


        public void UnirNodosHijo(Node nodoU)
        {
            //Cuenta cuantos datos hay en el nodo para asi ver si excede el limite 
            int Llavestotal = nodoU.Llaves.Count;
            int totalEdges = nodoU.Hijos.Count;
            Llavestotal += this.Llaves.Count;
            totalEdges += this.Hijos.Count;

            if (Llavestotal > 3 || totalEdges > 4)
            {
                //No hace nada por que excede el numero de limite de datos en nodo
                return;
            }

            for (int x = Hijos.Count - 1; x >= 0; x--)
            {
                Node nodetemp = nodoU.EliminarO(x);
                this.InsertarALaPar(nodetemp);

            }
            for (int x = 0; x < nodoU.Llaves.Count; x++)
            {
                string temp = nodoU.Llaves[x];
                this.AgregarValorNodo(temp);
            }
        }

        public void UnirNodosHijo(Node nodo1, Node nodo2)
        {
            int LLavesnum = nodo1.Llaves.Count;
            int totalEdges = nodo1.Hijos.Count;

            LLavesnum += nodo2.Llaves.Count;
            totalEdges += nodo2.Hijos.Count;
            LLavesnum += this.Llaves.Count;
            totalEdges += this.Hijos.Count;

            if (LLavesnum > 3)
            {
                //No hace nada por que excede el numero de limite de datos en nodo
            }

            this.UnirNodosHijo(nodo1);
            this.UnirNodosHijo(nodo2);
        }
        public Node[] Dividir()
        {
            if (Llaves.Count <= 2)
            {
                //No se puede dividir en 2 nodos por que aun hay espacio
            }

            Node Derechonuevo = new Node(Llaves[1]);

            for (int x = 2; x < Hijos.Count; x++) //Agrega los nodos a el nuevo nodo
            {
                Derechonuevo.Hijos.Add(this.Hijos[x]);
            }

            for (int x = Hijos.Count - 1; x >= 2; x--) //Elimina el nodo anterior
            {
                this.Hijos.RemoveAt(x);
            }

            for (int x = 1; x < Llaves.Count; x++)
            {
                Llaves.RemoveAt(x);
            }

            return new Node[] { this, Derechonuevo };
        }



        public Node Traverse(string k)
        {
            int pos = UltimoNodo(k);

            if (pos < Hijos.Count && pos > -1)
            {
                return Hijos[pos];
            }
            else
            {
                return null;
            }
        }

    }
}

