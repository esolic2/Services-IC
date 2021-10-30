using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebJenkins.Models
{
    public class mvcTbLoginModel
    {
        
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Usuario is Required to continue")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Password is Required to continue")]
        [DataType(DataType.Password)]
        public string contraseña { get; set; }

        public string loginErrorMessage { get; set; }
    }
}