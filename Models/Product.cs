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
        public decimal Multiple { get; set; }
        
        public string Image { get; set; }

        public StatusProduto Status { get; set; }
        public int CategoriaId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        
        [Display(Name="Data de Inclusão")]
        public DateTime CreateDate { get; set; }
        
        [Display(Name="Data de Alteração")]
        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O Preco deve ser maior que ZERO")]        
        [Display(Name="Preço Unitário de Compra")]
        public decimal UnitBuyPrice { get; set; }
        
        
        
        [Display(Name="% IPI")]
        public decimal IpiPercent { get; set; }        
        
        [Display(Name="% Frete")]
        public decimal ShippingPercent { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Display(Name="% ICMS")]
        public decimal IcmsPercent { get; set; }
        
        [Display(Name="MVA")]
        public decimal Mva { get; set; }
        
        [Display(Name="% Acréscimo")]
        public decimal AdditionsPercent { get; set; }
        
        
        [Display(Name="% Desconto")]
        public decimal DiscountPercent { get; set; }
        
        [Display(Name="Estoque")]
        public decimal Stock { get; set; }
        
        [Display(Name="Estoque Mínimo")]
        public decimal MinimumStock { get; set; }

        [Display(Name="Estoque Máximo")]
        public decimal MaximumStock { get; set; }

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
        public DateTime LastSaleDate { get; set; }

        [Display(Name="Data da Última Compra")]
        public DateTime LastBuyDate { get; set; }

        //Calculated Fields

        [Display(Name="Valor IPI")]
        public decimal IpiValue { 
            get { return UnitBuyPrice * IpiPercent / 100; }
        }

        [Display(Name="% Frete")]
        public decimal ShippingValue { get{ return UnitBuyPrice * ShippingPercent / 100; } }

        [Display(Name="MVA")]
        public decimal MvaValue { 
            get{ return (UnitBuyPrice + IpiValue + ShippingValue) * Mva / 100; } 
        }

        [Display(Name="Valor ICMS")]
        public decimal IcmsValue { 
            get  { return MvaValue * IcmsPercent / 100;}
         }
                
        [Display(Name="Valor Acréscimo")]
        public decimal AdditionsValue { get  { return (MvaValue + IcmsValue) * AdditionsPercent / 100;} }

        [Display(Name="Valor Desconto")]
        public decimal DiscountValue { get  { return AdditionsValue * DiscountPercent / 100;} }

        [Display(Name="Preço Unitário Mínimo de Venda")]
        public decimal UnitPriceMinimumSale { get  { return (MvaValue + IcmsValue + AdditionsValue + DiscountValue); }}
        
        [Display(Name="Preço Unitário Máximo de Venda")]
        public decimal UnitPriceMaximumSale { get  { return (MvaValue + IcmsValue + AdditionsValue); } }
        
    }
}