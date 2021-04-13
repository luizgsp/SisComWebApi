using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Category
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} caracteres")]
        [Display(Name= "Categoria")]
        public string Title { get; set; }

        [Display(Name= "Produtos")]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}