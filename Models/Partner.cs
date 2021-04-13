using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sócio")]
        public string Name { get; set; }

        [Display(Name = "Porcentagem")]
        public string Percent { get; set; }

        [Display(Name = "Desde de")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Since { get; set; }

        [Display(Name = "Observações")]
        public string Notes { get; set; }

        [Display(Name = "Documentos")]
        public ICollection<Document> Documents { get; set; } = new List<Document>();

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public void AddDocument(Document obj)
        {
            Documents.Add(obj);
        }

        public void RemoveDocument(Document obj)
        {
            Documents.Remove(obj);
        }
    }
}
