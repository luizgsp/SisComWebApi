using SisComWebApi.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public EnumAddressType AddressType { get; set; }

        [Display(Name = "Endereço")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Location { get; set; }

        [Display(Name = "Número")]
        [MaxLength(20, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Number { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(50, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Complement { get; set; }

        [Display(Name = "Bairro")]
        [MaxLength(100, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Block { get; set; }


        [Display(Name = "Cidade")]
        [MaxLength(100, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(2, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string State { get; set; }

        [Display(Name = "Código Postal")]
        [MaxLength(20, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string PostalCode { get; set; }

        [Display(Name = "Observações")]
        public string Notes { get; set; }

        [Display(Name = "Fornecedor")]
        public int SupplierId { get; set; }
        [Display(Name = "Fornecedor")]
        public Supplier Supplier { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }
    }
}
