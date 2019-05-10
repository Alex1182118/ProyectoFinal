using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoED1.Models
{
    public class DefColumna
    {
        public string nombreColumna { get; set; }
        public string tipoColumna { get; set; }
        public List<string> list_string { get; set; }
        public List<int> list_int { get; set; }
    }
}
