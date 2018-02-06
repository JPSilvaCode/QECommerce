using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 100 caracteres.")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Companhias")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Companhia")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}