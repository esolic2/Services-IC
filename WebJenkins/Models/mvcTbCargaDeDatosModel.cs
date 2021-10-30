using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebJenkins.Models
{
    public class mvcTbCargaDeDatosModel
    {
        public int IdRegistro { get; set; }
        public int DPI { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string TercerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Telefono { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public bool Covid19Positivo { get; set; }
        public string DosisAplicada { get; set; }
    }
}