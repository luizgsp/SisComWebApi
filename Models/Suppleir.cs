using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SisComWebApi.Models.Enums;

namespace SisComWebApi.Models
{
    public class Supplier
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        public string Name { get; set; }

        public EnumSupplierType SupplierType { get; set; }
        public char PersonType { get; set; }
        public Status Status { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalRegistration { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public double BuyLimit { get; set; }

        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public void AddPhone(Phone obj)
        {
            Phones.Add(obj);
        }

        public void RemovePhone(Phone obj)
        {
            Phones.Remove(obj);
        }

        public void AddBank(BankAccount obj)
        {
            BankAccounts.Add(obj);
        }

        public void RemoveBank(BankAccount obj)
        {
            BankAccounts.Remove(obj);
        }

        public void AddAddress(Address obj)
        {
            Addresses.Add(obj);
        }

        public void RemoveAddress(Address obj)
        {
            Addresses.Remove(obj);
        }
    }
}