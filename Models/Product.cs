using System;
using System.ComponentModel.DataAnnotations;

namespace SisComWebApi.Models
{
    public class Product
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [Display(Name="Código")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [Display(Name="Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name="Unidade")]
        public string Unit { get; set; }

        [Display(Name="Referência")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]        
        [Display(Name="Marca")]
        public string Brand { get; set; }
        
        [Display(Name="Medida")]
        public string Measures { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O múltiplo deve ser maior que ZERO")]        
        [Display(Name="Múltiplo")]
        public double Multiple { get; set; }
        
        public string Image { get; set; }

        public Status Status { get; set; }
        public int CategoriaId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        
        [Display(Name="Data de Inclusão")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        
        [Display(Name="Data de Alteração")]
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O Preco NÃO deve conter valor negativo")]        
        [Display(Name="Preço Unitário de Compra")]
        public double UnitBuyPrice { get; set; }
        
        
        
        [Display(Name="% IPI")]
        [Range(0, 100, ErrorMessage = "O IPI deve ser de 0 a 100%")]        
        public double IpiPercent { get; set; }        
        
        [Display(Name="% Frete")]
        public double ShippingPercent { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Range(0, 100, ErrorMessage = "O ICMS deve ser de 0 a 100%")]        
        [Display(Name= "% ICMS")]
        public double IcmsPercent { get; set; }
        
        [Display(Name="MVA")]
        [Range(0, 100, ErrorMessage = "O MVA deve ser de 0 a 100%")]        
        public double Mva { get; set; }
        
        [Display(Name="% Acréscimo")]
        [Range(0, 100, ErrorMessage = "O campo deve ser de 0 a 100%")]        
        public double AdditionsPercent { get; set; }
        
        
        [Display(Name="% Desconto")]
        [Range(0, 100, ErrorMessage = "O campo deve ser de 0 a 100%")]        
        public double DiscountPercent { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Display(Name= "Estoque")]
        [Range(0, int.MaxValue, ErrorMessage = "O Estoque deve ser maior que ZERO")]        
        public double Stock { get; set; }
        
        [Display(Name="Estoque Mínimo")]
        public double MinimumStock { get; set; }

        [Display(Name="Estoque Máximo")]
        public double MaximumStock { get; set; }

        [Display(Name="Substituição Tributária")]
        public bool TaxSubstitution { get; set; }

        [Display(Name="Classificação Fiscal")]
        public string FiscalClassification { get; set; }
        public string Cfop { get; set; }

        [Display(Name="Natureza da Operação")]
        public string NatOper { get; set; }

        [Display(Name="Código do Fornecedor")]
        public string SupplierCode { get; set; }

        [Display(Name="Código de Barras")]
        public string BarCode { get; set; }

        [Display(Name="Data da Última Venda")]
        [DataType(DataType.Date)]
        public DateTime LastSaleDate { get; set; }

        [Display(Name="Data da Última Compra")]
        [DataType(DataType.Date)]
        public DateTime LastBuyDate { get; set; }

        //Calculated Fields

        [Display(Name="Valor IPI")]
        public double IpiValue { 
            get { return UnitBuyPrice * IpiPercent / 100; }
        }

        [Display(Name="% Frete")]
        public double ShippingValue { get{ return UnitBuyPrice * ShippingPercent / 100; } }

        [Display(Name="MVA")]
        public double MvaValue { 
            get{ return (UnitBuyPrice + IpiValue + ShippingValue) * Mva / 100; } 
        }

        [Display(Name="Valor ICMS")]
        public double IcmsValue { 
            get  { return MvaValue * IcmsPercent / 100;}
         }
                
        [Display(Name="Valor Acréscimo")]
        public double AdditionsValue { get  { return (MvaValue + IcmsValue) * AdditionsPercent / 100;} }

        [Display(Name="Valor Desconto")]
        public double DiscountValue { get  { return AdditionsValue * DiscountPercent / 100;} }

        [Display(Name="Preço Unitário Mínimo de Venda")]
        public double UnitPriceMinimumSale { get  { return (MvaValue + IcmsValue + AdditionsValue + DiscountValue); }}
        
        [Display(Name="Preço Unitário Máximo de Venda")]
        public double UnitPriceMaximumSale { get  { return (MvaValue + IcmsValue + AdditionsValue); } }
        
    }
}