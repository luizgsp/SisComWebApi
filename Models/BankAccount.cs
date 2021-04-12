using SisComWebApi.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
