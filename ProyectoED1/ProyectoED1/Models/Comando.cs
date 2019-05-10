using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoED1.Models
{
    public class Comando
    {
        [DataType(DataType.MultilineText)]
        public string TextoComando { get; set; }
        public string Resultado { get; set; }
    }
}
