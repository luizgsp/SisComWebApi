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
        public string Location { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Block { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
