using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResortTropicalBeach.Models
{
    public class habitacion
    {
        public int Id { get; set; }

       [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int piso { get; set; }

       [Required(ErrorMessage = "El campo {0} es obligatorio.")]
       public int nHabitacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10)]
        public string tipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(1000)]
        public string detalles { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Boolean disponible { get; set; }


    }
}
