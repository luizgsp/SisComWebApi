using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SisComWebApi.Models.Enums;

namespace SisComWebApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(20, MinimumLength = 11, ErrorMessage = "{0} deve conter no mínimo {2} caracteres")]
        [Display(Name= "CNPJ/CPF")]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} caracteres")]
        [Display(Name= "Nome/Razão Social")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Pessoa")]
        public char PersonType { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [MaxLength(30, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string StateRegistration { get; set; }

        [Display(Name = "Inscrição Municipal")]
        [MaxLength(30, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string MunicipalRegistration { get; set; }

        [Display(Name = "Contato")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
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

        [Display(Name = "Sócios")]
        public ICollection<Partner> Partners { get; set; } = new List<Partner>();

        public void AddPhone(Phone obj)
        {
            Phones.Add(obj);
        }

        public void RemovePhone(Phone obj)
        {
            Phones.Remove(obj);
        }

        public void AddAddress(Address obj)
        {
            Addresses.Add(obj);
        }

        public void RemoveAddress(Address obj)
        {
            Addresses.Remove(obj);
        }

        public void AddPartner(Partner obj)
        {
            Partners.Add(obj);
        }

        public void RemovePartner(Partner obj)
        {
            Partners.Remove(obj);
        }
    }
}
