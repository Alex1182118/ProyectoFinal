using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoED1.Models;
using ProyectoED1.Repositories;

namespace ProyectoED1.Controllers
{
    public class ComandoController : Controller
    {
        ITablaRepository _tablaRepository;
        public static List<DefColumna> ValoresColumna = new List<DefColumna>();
        DefColumna Valores = new DefColumna();
        public ComandoController(ITablaRepository tablaRepository)
        {
            _tablaRepository = tablaRepository;
        }

        // GET: Comando
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comando/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public string EjecutarComando(string Comando)
        {
            string[] palabras = Comando.Split(" ");
            int estado = 0;
            string id = "";
            string nombreTabla = "";
            string tipoComando = "";
            List<DefColumna> listaDefColumnas = new List<DefColumna>();
            List<string> listaDeValores = new List<string>();
            List<string> listadeColumnas = new List<string>();
            List<string> listacolumnasselect = new List<string>();
            DefColumna tmp = new DefColumna();
            string resultado = "";
            foreach (var palabra in palabras)
            {
                switch (estado)
                {
                    case 0:
                        if (palabra.ToUpper() == "CREATE")
                        {
                            estado = 1;
                        }
                        else if (palabra.ToUpper() == "SELECT")
                        {
                            estado = 22;
                        }
                        else if (palabra.ToUpper() == "INSERT")
                        {
                            estado = 10;
                        }
                        else if (palabra.ToUpper() == "DELETE")
                        {
                            estado = 26;
                        }
                        else if (palabra.ToUpper() == "DROP")
                        {
                            estado = 29;
                            tipoComando = "DROP_TABLE";


                        }
                        break;
                    case 29:
                        if (palabra == "TABLE")
                        {
                            estado = 30;
                        }
                        break;
                    case 30:
                        nombreTabla = palabra;
                        estado = 7;
                        break;
                    case 26:
                        if (palabra == "FROM")
                        {
                            estado = 2;
                        }
                        break;
                    case 1:
                        if (palabra.ToUpper() == "TABLE")
                        {
                            tipoComando = "CREAR_TABLA";
                            estado = 2;
                        }
                        break;
                    case 2:
                        nombreTabla = palabra;
                        estado = 3;
                        break;
                    case 3:
                        if (palabra == "(")
                        {
                            estado = 4;
                        }
                        else if (palabra == "WHERE")
                        {
                            estado = 23;
                        }
                        break;
                    case 4:
                        tmp = new DefColumna();
                        tmp.nombreColumna = palabra;
                        estado = 5;
                        break;
                    case 5:
                        tmp.tipoColumna = palabra;
                        listaDefColumnas.Add(tmp);
                        estado = 6;
                        break;
                    case 6:
                        if (palabra == ",")
                        {
                            estado = 4;
                        }
                        else if (palabra == ")")
                        {
                            estado = 7;
                        }
                        break;
                    case 7:
                        if (palabra.ToUpper() == "GO")
                        {

                            if (tipoComando == "CREAR_TABLA")
                            {
                                //termine y creo el archivo y el arbol, devolver tabla creada correctamente
                                _tablaRepository.CrearTabla(nombreTabla, listaDefColumnas);
                                resultado = "Tabla creada exitosamente";
                            }
                            else if (tipoComando == "SELECCIONAR_VALORES")
                            {
                                resultado = "SELECCIONAR_VALORES";
                                _tablaRepository.VerColumnasSelect(nombreTabla, listacolumnasselect);
                            }
                            else if (tipoComando == "INSERT_INTO")
                            {
                                resultado = "INSERT_INTO";
                                _tablaRepository.InsertarValores(nombreTabla, listaDeValores);
                            }
                            else if (tipoComando == "DELETE")
                            {
                                resultado = "DELETE";
                                _tablaRepository.EliminarValores(tmp.nombreColumna, nombreTabla, id);
                                Valores.list_string = listaDeValores;
                            }
                            else if (tipoComando == "DROP_TABLE")
                            {
                                resultado = "DROP_TABLE";
                                _tablaRepository.DropTable(nombreTabla);
                            }
                       
                        }
                        break;
                    case 8:
                        if (palabra.ToUpper() == "FROM")
                        {
                            estado = 9;
                        }
                        break;
                    case 22:
                        listacolumnasselect.Add(palabra);
                        estado = 27;
                        break;
                    case 27:
                        if (palabra == ",")
                        {
                            estado = 22;
                        }
                        else if (palabra != "FROM")
                        {
                            estado = 22;
                        }
                        else 
                        {
                            estado = 9;
                        }
                        break;

                    case 28:
                        if (palabra.ToUpper() == "FROM")
                        {
                            estado = 9;
                        }

                        break;
                    case 9:
                        nombreTabla = palabra;
                        tipoComando = "SELECCIONAR_VALORES";
                        estado = 7;
                        break;
                    case 10:
                        if (palabra.ToUpper() == "INTO")
                        {
                            tipoComando = "INSERT_INTO";
                            estado = 11;
                        }
                        break;
                    case 11:
                        nombreTabla = palabra;
                        estado = 12;

                        break;
                    case 12:
                        if (palabra == "(")
                        {
                            estado = 14;
                        }
                        break;
                    case 13:
                        listadeColumnas.Add(palabra);
                        estado = 14;
                        break;
                    case 14:
                        if (palabra == ",")
                        {
                            estado = 13;
                        }
                        else if (palabra == ")")
                        {
                            estado = 15;
                        }
                        break;
                    case 15:
                        if (palabra == "VALUES")
                        {
                            estado = 16;
                        }
                        break;
                    case 16:
                        if (palabra == "(")
                        {
                            estado = 17;
                        }
                        break;
                    case 17:
                        listaDeValores.Add(palabra);
                        estado = 18;
                        break;
                    case 18:
                        if (palabra == ",")
                        {
                            estado = 17;
                        }
                        else if (palabra == ")")
                        {
                            estado = 7;
                        }
                        break;
                    case 23:
                        tmp.nombreColumna = palabra;
                        estado = 24;
                        break;
                    case 24:
                        if (palabra == "=")
                        {
                            estado = 25;
                        }
                        break;
                    case 25:
                        id = palabra;
                        estado = 7;
                        tipoComando = "DELETE";
                        break;

                    default:
                        break;
                }
            }
            return resultado;
        }

        // GET: Comando/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comando/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Comando comando)
        {
            try
            {
                // TODO: Add insert logic here
                string result = EjecutarComando(comando.TextoComando);
                //Retornar resultado
                if (result == "Tabla creada exitosamente")
                {
                    return Redirect("/Tabla/Columnas/" + result);
                }
                if (result == "DELETE")
                {
                    return Redirect("/Tabla/Columnas/" + result);
                }
                if (result == "INSERT_INTO")
                {
                    return Insert(result);
                }
                if (result == "SELECCIONAR_VALORES")
                {
                    return Select(result);
                    
                }
               
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Select(string result)
        {
            try
            {
                // TODO: Add insert logic here

                if (result =="SELECCIONAR_VALORES")
                {
                   return Redirect("/Tabla/ColumnasSelect/" + result);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Insert(string result)
        {
            try
            {
                // TODO: Add insert logic here
                
                if (result == "INSERT_INTO")
                {
                    return Redirect("/Tabla/Insert/" + result);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Comando/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comando/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Comando/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comando/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}