using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [MetadataType(typeof(TbLogin.MetaData))]
    public partial class TbLogin
    {
        sealed class MetaData
        {
            [Required]
            public string Usuario;
            [Required]
            public string contraseña;
        }
    }
}
