using ProyectoED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ArbolDLL;

namespace ProyectoED1.Repositories
{
    public class TablaRepository : ITablaRepository
    {
       string basePath = @"C:\Users\user\Documents\ProyectoED1\Tablas";
        List<DefTabla> listaDeTablas = new List<DefTabla>();
        List<DefColumna> listaDeColumnas = new List<DefColumna>();
        List<DefColumna> listatmp = new List<DefColumna>();
        List<DefColumna> Listavaloresselect = new List<DefColumna>();
        List<string> listaDeValores = new List<string>();
        DefColumna nuevaColumna = new DefColumna();
        public List<DefTabla> ObtenerTablas()
        {
            //leer basePath y
            return new List<DefTabla>();
        }

        public void CrearTabla(string nombreTabla, List<DefColumna> columnas)
        {
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(nombreTabla.ToUpper() + ".tabla"))
            {
                streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(columnas));
                streamWriter.Close();
            }
            DefTabla nuevaTabla = new DefTabla();
            nuevaTabla.Nombre = nombreTabla;
            nuevaTabla.columnas = columnas;
            listaDeColumnas = columnas;
            listaDeTablas.Add(nuevaTabla);
        }
        public List<DefColumna> VerColumnas()
        {
            return listaDeColumnas;
        }

        public void DropTable(string nombreTabla)
        {

                                                           

            if (System.IO.File.Exists("VALORES" + nombreTabla.ToUpper() + ".arbol"))
            {


                System.IO.File.Delete("VALORES" + nombreTabla.ToUpper() + ".arbol");

            }
            if (System.IO.File.Exists(nombreTabla.ToUpper() + ".tabla"))
            {
                System.IO.File.Delete(nombreTabla.ToUpper() + ".tabla");
            }
            if (System.IO.File.Exists("VALORES" + nombreTabla.ToUpper() + ".tabla"))
            {

                System.IO.File.Delete("VALORES" + nombreTabla.ToUpper() + ".tabla");
            }


        }



        public void VerColumnasSelect(string nombreTabla, List<string> listacolumnasselect)
        {
          ArbolB arbolb = new ArbolB();
            if (!File.Exists("VALORES" + nombreTabla.ToUpper() + ".arbol"))
            {

                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("VALORES" + nombreTabla.ToUpper() + ".arbol"))
                {

                  streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(arbolb));
                    streamWriter.Close();
                }
            }
            if (File.Exists(nombreTabla.ToUpper() + ".tabla"))
            {

                listaDeColumnas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DefColumna>>(File.ReadAllText(nombreTabla.ToUpper() + ".tabla"));


            }
            DefColumna tmp = new DefColumna();
            DefColumna tmp2 = new DefColumna();
            DefColumna tmp3 = new DefColumna();
            List<DefColumna> tmplistas = new List<DefColumna>();
            for (int i = 0; i < listacolumnasselect.Count(); i++)
            {
                tmp.nombreColumna = listacolumnasselect[i];
                tmp2 = listaDeColumnas[i];
                if (listacolumnasselect[i] == tmp2.nombreColumna)
                {
                    tmp.tipoColumna = listaDeColumnas[i].tipoColumna;
                    tmp.list_string = listaDeColumnas[i].list_string;
                    tmplistas.Add(tmp);
                }

            }
            listaDeColumnas = tmplistas;

        }

        public List<DefTabla> VerTablas()
        {
            return listaDeTablas;
        }

      public bool ExisteLaTabla(string nombreTabla)
        {
            bool existe = false;
            if (File.Exists(nombreTabla.ToUpper() + ".tabla"))
            {
               StreamReader str = new StreamReader(nombreTabla.ToUpper() + ".tabla");
               listaDeColumnas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DefColumna>>(str.Read().ToString());
                return existe= true;
            }
            else { return existe; }
          
        }

        public bool ValidarColumna(string nombreTabla, string nombreColumna)
        {
            bool valido = false;
            foreach (var item in listaDeTablas)
            {
                if (item.Nombre == nombreTabla)
                {
                    foreach (var i in item.columnas)
                    {
                        if (i.nombreColumna == nombreColumna)
                        {
                            valido = true;
                        }
                        else
                        {
                            valido = false;
                        }
                    }
                }
                else
                {
                    valido = false;
                }
            }
            return valido;
        }
        public void EliminarValores(string nombrecolumna, string nombretabla, string id)
            {
           /* ArbolB arbolb = new ArbolB();
            Node nodotmp = new Node();
            if (File.Exists("VALORES" + nombretabla.ToUpper() + ".arbol"))
            {

                using (System.IO.StreamReader str = new System.IO.StreamReader("VALORES" + nombretabla.ToUpper() + ".arbol"))
                {

                  arbolb = Newtonsoft.Json.JsonConvert.DeserializeObject<ArbolB>("VALORES" + nombretabla.ToUpper() + ".arbol");
                    str.Close();
                }
            }
              nodotmp = arbolb.Buscar(id);
             arbolb.Eliminar(id);
             */
            DefColumna tmp = new DefColumna();
            if (File.Exists("VALORES"+ nombretabla.ToUpper() + ".tabla"))
                {

                    tmp = Newtonsoft.Json.JsonConvert.DeserializeObject<DefColumna>(File.ReadAllText("VALORES" + nombretabla.ToUpper() + ".tabla"));

                }
            if (tmp.list_string.Contains(id))
            {
                if (System.IO.File.Exists("VALORES" + nombretabla.ToUpper() + ".arbol"))
                {

                    System.IO.File.Delete("VALORES" + nombretabla.ToUpper() + ".arbol");

                }
                if (System.IO.File.Exists(nombretabla.ToUpper() + ".tabla"))
                {
                    System.IO.File.Delete(nombretabla.ToUpper() + ".tabla");
                }
                if (System.IO.File.Exists("VALORES" + nombretabla.ToUpper() + ".tabla"))
                {

                    System.IO.File.Delete("VALORES" + nombretabla.ToUpper() + ".tabla");
                }

            }

        }
        public void InsertarValores(string tabla, List<string> valorNodo)
        {

         ArbolB arbolb = new ArbolB();
            foreach (var valor in valorNodo)
            {
              arbolb.Insertar(valor);
            }
            if (!File.Exists("VALORES" + tabla.ToUpper() + ".arbol"))
            {

                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("VALORES" + tabla.ToUpper() + ".arbol"))
                {

                    streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(arbolb));
                    streamWriter.Close();
                }

            }
            if (File.Exists(tabla.ToUpper() + ".tabla"))
            {
            
                listaDeColumnas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DefColumna>>(File.ReadAllText(tabla.ToUpper() + ".tabla"));

 
            }
            
            nuevaColumna.list_string = valorNodo;
            nuevaColumna.nombreColumna = tabla;
            listaDeColumnas.Add(nuevaColumna);
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter( "VALORES" + tabla.ToUpper() + ".tabla"))
            {
                streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(nuevaColumna));
                streamWriter.Close();
            }
        }

        //Crear arbol con llave ID

        void HandlePredicate(DefColumna obj)
        {
        }

    }
}

