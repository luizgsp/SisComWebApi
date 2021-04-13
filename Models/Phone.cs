using SisComWebApi.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Número")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até 150 caracteres")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tipo")]
        public EnumPhoneType PhoneType { get; set; }

        [Display(Name = "Fornecedor")]
        public int SupplierId { get; set; }
        [Display(Name = "Fornecedor")]
        public Supplier Supplier { get; set; }
    }
}
