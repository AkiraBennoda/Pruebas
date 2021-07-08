using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{ 
    [MetadataType(typeof(Alumnos.MedaData))]
    public partial class Alumnos
    {
        sealed class MedaData
        {
          
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Apellido { get; set; }

            [Required]
            public string Matricula { get; set; }

        }
    }
}