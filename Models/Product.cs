using System;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Product
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} a {1} caractéres")]
        [Display(Name="Código")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} a {1} caractéres")]
        [Display(Name="Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} deve conter entre {2} a {1} caractéres")]
        [Display(Name="Unidade")]
        public string Unit { get; set; }

        [Display(Name="Referência")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até 150 caracteres")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]        
        [StringLength(55, MinimumLength = 3, ErrorMessage = "{0} deve conter entre {2} a {1} caractéres")]
        [Display(Name="Marca")]
        public string Brand { get; set; }
        
        [Display(Name="Medida")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até 150 caracteres")]
        public string Measures { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} deve ser maior que ZERO")]        
        [Display(Name="Múltiplo")]
        public double Multiple { get; set; }
        
        public string Image { get; set; }

        public Status Status { get; set; }
        [Display(Name="Categoria")]
        public int CategoriaId { get; set; }
        [Display(Name="Categoria")]
        public Category Category { get; set; }
        [Display(Name= "Fornecedor")]
        public int SupplierId { get; set; }
        [Display(Name= "Fornecedor")]
        public Supplier Supplier { get; set; }

        
        [Display(Name="Data de Inclusão")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        
        [Display(Name="Data de Alteração")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} NÃO deve conter valor negativo")]        
        [Display(Name="Preço Unitário de Compra")]
        public double UnitBuyPrice { get; set; }
        
        
        
        [Display(Name="% IPI")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 100, ErrorMessage = "{0} deve ser de 0 a 100%")]        
        public double IpiPercent { get; set; }        
        
        [Display(Name="% Frete")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 999, ErrorMessage = "{0} deve ser de 0 a 100%")]        
        public double ShippingPercent { get; set; }

        [Required(ErrorMessage = "{0}  é obrigatório")] 
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 100, ErrorMessage = "{0} deve ser de 0 a 100%")]        
        [Display(Name= "% ICMS")]
        public double IcmsPercent { get; set; }
        
        [Display(Name="MVA")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 100, ErrorMessage = "{0} deve ser de 0 a 100%")]        
        public double Mva { get; set; }
        
        [Display(Name="% Acréscimo")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 999, ErrorMessage = "{0} deve ser de 0 a 100%")]        
        public double AdditionsPercent { get; set; }
        
        
        [Display(Name="% Desconto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, 100, ErrorMessage = "{0} ser de 0 a 100%")]        
        public double DiscountPercent { get; set; }
        
        [Required(ErrorMessage = "{0}  é obrigatório")] 
        [Range(0, int.MaxValue, ErrorMessage = "{0} deve ser maior que ZERO")]        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name= "Estoque")]
        public double Stock { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} deve ser maior que ZERO")]        
        [Display(Name= "Estoque Mínimo")]
        public double MinimumStock { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} deve ser maior que ZERO")]        
        [Display(Name= "Estoque Máximo")]
        public double MaximumStock { get; set; }

        [Display(Name="Substituição Tributária")]
        public bool TaxSubstitution { get; set; }

        [Display(Name="Classificação Fiscal")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string FiscalClassification { get; set; }

        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string Cfop { get; set; }

        [Display(Name="Natureza da Operação")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string NatOper { get; set; }

        [Display(Name="Código do Fornecedor")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string SupplierCode { get; set; }

        [Display(Name="Código de Barras")]
        [MaxLength(55, ErrorMessage = "{0} deve conter até {1} caracteres")]
        public string BarCode { get; set; }

        [Display(Name="Data da Última Venda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastSaleDate { get; set; }

        [Display(Name="Data da Última Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastBuyDate { get; set; }

        //Calculated Fields

        [Display(Name="Valor IPI")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double IpiValue
        { 
            get { return UnitBuyPrice * IpiPercent / 100; }
        }

        [Display(Name="% Frete")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ShippingValue { get{ return UnitBuyPrice * ShippingPercent / 100; } }

        [Display(Name="MVA")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double MvaValue
        { 
            get{ return (UnitBuyPrice + IpiValue + ShippingValue) * Mva / 100; } 
        }

        [Display(Name="Valor ICMS")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double IcmsValue
        { 
            get  { return MvaValue * IcmsPercent / 100;}
         }
                
        [Display(Name="Valor Acréscimo")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AdditionsValue { get  { return (MvaValue + IcmsValue) * AdditionsPercent / 100;} }

        [Display(Name="Valor Desconto")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double DiscountValue { get  { return AdditionsValue * DiscountPercent / 100;} }

        [Display(Name="Preço Unitário Mínimo de Venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double UnitPriceMinimumSale { get  { return (MvaValue + IcmsValue + AdditionsValue + DiscountValue); }}
        
        [Display(Name="Preço Unitário Máximo de Venda")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double UnitPriceMaximumSale { get  { return (MvaValue + IcmsValue + AdditionsValue); } }
        
    }
}