using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Documento")]
        public string Title { get; set; }

        [Display(Name = "Sócio")]
        public int PartnerId { get; set; }
        [Display(Name = "Sócio")]
        public Partner Partner { get; set; }
    }
}
