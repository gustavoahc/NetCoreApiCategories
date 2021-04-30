using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
    }
}
