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

        [Display(Name= "Tipo de Fornecedor")]
        public EnumSupplierType SupplierType { get; set; }

        [Display(Name= "Tipo de Pessoa")]
        public char PersonType { get; set; }
        public Status Status { get; set; }

        [Display(Name= "Inscrição Estadual")]
        public string StateRegistration { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string MunicipalRegistration { get; set; }

        [Display(Name = "Contato")]
        public string Contact { get; set; }


        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Website { get; set; }

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Display(Name = "Observações")]
        public string Notes { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Ultima Atualização")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Limite de Crédito")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BuyLimit { get; set; }

        [Display(Name = "Telefones")]
        public ICollection<Phone> Phones { get; set; } = new List<Phone>();

        [Display(Name = "Endereços")]
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        [Display(Name = "Contas Bancaria")]
        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        [Display(Name = "Produtos")]
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

        public void AddProduct(Product obj)
        {
            Products.Add(obj);
        }

        public void RemoveProduct(Product obj)
        {
            Products.Remove(obj);
        }
    }
}