using ProyectoED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoED1.Repositories
{
    public interface ITablaRepository
    {
        List<DefTabla> ObtenerTablas();
        void CrearTabla(string nombreTabla, List<DefColumna> columnas);
        void InsertarValores(string tabla, List<string>listaDeValores);
        List<DefColumna> VerColumnas();
         void VerColumnasSelect(string nombreTabla, List<string> listacolumnasselect);
        void EliminarValores(string tabla, string nombretabla, string id);
        void DropTable(string tabla);
        List<DefTabla> VerTablas();
        bool ExisteLaTabla(string nombreTabla);
        bool ValidarColumna(string nombreTabla, string nombreColumna);
    }
}
