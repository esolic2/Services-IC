using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [MetadataType(typeof(TbCapturaDeDatos.MetaData))]
    public partial class TbCapturaDeDatos
    {
        sealed class MetaData
        {
            [Required]
            public int DPI;
            [Required]
            public string PrimerNombre;
            [Required]
            public string PrimerApellido;
            [Required]
            public string Sexo;
            [Required]
            public string EstadoCivil;
            [Required]
            public string Direccion;
            [Required]
            public System.DateTime FechaNacimiento;
            [Required]
            public bool Covid19Positivo;
        }
    }
}