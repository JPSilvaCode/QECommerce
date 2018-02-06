using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Produto")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Companhias")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Companhia")]
        [Index("Product_Description_CompanyId_Index", 1, IsUnique = true)]
        [Index("Product_BarCode_CompanyId_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 100 caracteres.")]
        [Index("Product_Description_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Código de Barras")]
        [MaxLength(20, ErrorMessage = "O campo {0} recebe no máximo 20 caracteres.")]
        [Index("Product_BarCode_CompanyId_Index", 2, IsUnique = true)]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma taxa")]
        [Display(Name = "Taxa")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Categoria")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Estoque")]
        public double Stock { get { return (Inventory == null ? 0 : Inventory.Sum(i => i.Stock)); } }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é requerido.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Anotações")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual Company Company { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<OrderDetailTmp> OrderDetailTmp { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<PurchaseDetailTmp> PurchaseDetailTmps { get; set; }
    }
}