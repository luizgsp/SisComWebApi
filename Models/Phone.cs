using SisComWebApi.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public EnumPhoneType PhoneType { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
