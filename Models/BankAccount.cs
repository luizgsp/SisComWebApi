using SisComWebApi.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Núm. Banco")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string BankNumber { get; set; }

        [Display(Name = "Nome Banco")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string BankName { get; set; }

        [Display(Name = "Agência")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Agency { get; set; }

        [Display(Name = "Conta")]
        [MaxLength(150, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Account { get; set; }

        [Display(Name = "Observações")]
        public string Notes { get; set; }


        [Display(Name = "Fornecedor")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }
    }
}
